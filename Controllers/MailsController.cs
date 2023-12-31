﻿using Mailer.Repository;
using Mailer.Infrastructure;
using Mailer.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using Mailer.Models;
using Microsoft.EntityFrameworkCore;
using Mailer.ViewModels;

namespace Mailer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailsController : ControllerBase
    {
        private IMailService _service { get; set; }
        private IMailRepository _repository { get; set; }
        public MailsController(IMailService service, IMailRepository repository) 
        {
            _service = service;
            _repository = repository;
        }
        /// <summary>
        /// Получить список сообщений.
        /// </summary>
        /// <returns>Список в формате Json.</returns>
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            var requests = await _repository.Request.Include(p=>p.Message).Include(p=>p.FailedMessage).Include(p=>p.Result).Include(p=>p.Recipient).ToListAsync();
            List<SentMsgViewModel> messages = new List<SentMsgViewModel>();
            foreach (var req in requests)
            {
                SentMsgViewModel message = new SentMsgViewModel()
                {
                    SendDate = req.CreateDate.ToShortDateString(),
                    Recipient = req.Recipient.Email,
                    Result = req.Result.Name,
                    FailedMessage = req.FailedMessage.Message,
                    Subject = req.Message.Subject,
                    Body = req.Message.Body
                };
                messages.Add(message);
            }
            return new JsonResult(messages);
        }
        /// <summary>
        /// Отправить новое сообщение.
        /// </summary>
        /// <param name="paramInfo">Заголовок, тело и получатели сообщения в формате Json.</param>
        [HttpPost]
        public async void Post([FromBody] ParamInfo paramInfo)
        {
            List<string> emails = paramInfo.Recipients.ToList();
            Dictionary<string, string> successSendEmails = new Dictionary<string, string>();
            foreach (var email in emails)
            {
                successSendEmails.Add(email, "");
            }
            Dictionary<string, string> failedSendToException = new Dictionary<string, string>();
            Message msg = new Message() { Subject = paramInfo.Subject, Body = paramInfo.Body };
            _repository.Context.Add(msg);
            try
            {
                await _service.SendMsgTo(emails, paramInfo.Subject, paramInfo.Body);
            }
            catch (SmtpException ex)
            {
                if (ex is SmtpFailedRecipientsException)
                {
                    SmtpFailedRecipientsException recipientsEx = (SmtpFailedRecipientsException)ex;

                    foreach (var item in recipientsEx.InnerExceptions)
                    {
                        failedSendToException.Add(item.FailedRecipient.Replace("<", string.Empty).Replace(">", string.Empty), item.Message);
                        successSendEmails.Remove(item.FailedRecipient.Replace("<", string.Empty).Replace(">", string.Empty));
                    }
                    RequestHelper.InsertData(_repository, successSendEmails, "Ok", msg);
                    RequestHelper.InsertData(_repository, failedSendToException, "Fail", msg);
                }
                else
                {
                    foreach (var email in emails)
                    {
                        failedSendToException.Add(email, ex.Message);
                    }
                    RequestHelper.InsertData(_repository, failedSendToException, "Fail", msg);

                }
            }
            _repository.Context.SaveChanges();
        }
    }
}
