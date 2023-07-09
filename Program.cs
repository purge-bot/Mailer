using Mailer.Configuration;
using Mailer.Repository;
using Mailer.Services;
using Microsoft.EntityFrameworkCore;

namespace Mailer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            IWebHostEnvironment environment = builder.Environment;
            IServiceCollection services = builder.Services;

            var config = builder.Configuration;
            config.AddJsonFile("mailsettings.json");
            ConfigureServices(services, config);

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var _emailRepository = scope.ServiceProvider.GetRequiredService<IMailRepository>();
                AppDbContext.InsertToResult(scope.ServiceProvider);
            }

            app.MapDefaultControllerRoute();
            app.MapGet("/", () => "Hello World!");

            app.Run();
        }

        public static void ConfigureServices(IServiceCollection services, IConfiguration config)
        {
            services.AddControllers();
            services.AddTransient<IMailRepository, MailRepository>();
            services.AddDbContext<AppDbContext>(option => option.UseNpgsql(
                config["Data:Mailer:ConnectionString"]));
            services.AddTransient<IMailService, MailService>();
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            services.Configure<MailSettings>(config.GetSection(nameof(MailSettings)));
        }
    }
}