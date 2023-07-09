﻿// <auto-generated />
using System;
using Mailer.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Mailer.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230708111259_Create_Relation_Recipient_To_Request")]
    partial class Create_Relation_Recipient_To_Request
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Mailer.Models.FailedMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("FailedMessage");
                });

            modelBuilder.Entity("Mailer.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Subject")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("Mailer.Models.Recipient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Recipient");
                });

            modelBuilder.Entity("Mailer.Models.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("FailedMessageId")
                        .HasColumnType("integer");

                    b.Property<int?>("MessageId")
                        .HasColumnType("integer");

                    b.Property<int?>("RecipientId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FailedMessageId");

                    b.HasIndex("MessageId");

                    b.HasIndex("RecipientId");

                    b.ToTable("Request");
                });

            modelBuilder.Entity("Mailer.Models.Result", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Result");
                });

            modelBuilder.Entity("Mailer.Models.Sender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Sender");
                });

            modelBuilder.Entity("Mailer.Models.Request", b =>
                {
                    b.HasOne("Mailer.Models.FailedMessage", "FailedMessage")
                        .WithMany("Request")
                        .HasForeignKey("FailedMessageId");

                    b.HasOne("Mailer.Models.Message", "Message")
                        .WithMany("Request")
                        .HasForeignKey("MessageId");

                    b.HasOne("Mailer.Models.Recipient", "Recipient")
                        .WithMany("Request")
                        .HasForeignKey("RecipientId");

                    b.Navigation("FailedMessage");

                    b.Navigation("Message");

                    b.Navigation("Recipient");
                });

            modelBuilder.Entity("Mailer.Models.FailedMessage", b =>
                {
                    b.Navigation("Request");
                });

            modelBuilder.Entity("Mailer.Models.Message", b =>
                {
                    b.Navigation("Request");
                });

            modelBuilder.Entity("Mailer.Models.Recipient", b =>
                {
                    b.Navigation("Request");
                });
#pragma warning restore 612, 618
        }
    }
}
