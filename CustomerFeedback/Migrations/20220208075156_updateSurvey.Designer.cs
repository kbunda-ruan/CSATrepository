﻿// <auto-generated />
using System;
using CustomerFeedback.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CustomerFeedback.Migrations
{
    [DbContext(typeof(CSATContext))]
    [Migration("20220208075156_updateSurvey")]
    partial class updateSurvey
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CustomerFeedback.Models.Administrator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .HasMaxLength(200)
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("EmpId")
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("NameFirst")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("NameLast")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("Title")
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("Id");

                    b.ToTable("Administrator");
                });

            modelBuilder.Entity("CustomerFeedback.Models.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(200)
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("NameFirst")
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("NameLast")
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Note")
                        .HasMaxLength(1000)
                        .HasColumnType("VARCHAR(1000)");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("Title")
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("CustomerFeedback.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ContactId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Note")
                        .HasMaxLength(1000)
                        .HasColumnType("VARCHAR(1000)");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("Type")
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Url")
                        .HasMaxLength(200)
                        .HasColumnType("VARCHAR(200)");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("CustomerFeedback.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Options")
                        .HasColumnType("VARCHAR");

                    b.Property<string>("QuestionKpiType")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("QuestionType")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("VARCHAR(1000)");

                    b.HasKey("Id");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("CustomerFeedback.Models.Survey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AdministratorId")
                        .HasColumnType("int");

                    b.Property<string>("Audience")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("VARCHAR(250)");

                    b.Property<DateTime?>("ExpireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("Id");

                    b.HasIndex("AdministratorId");

                    b.ToTable("Survey");
                });

            modelBuilder.Entity("CustomerFeedback.Models.SurveyQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<int>("SurveyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("SurveyId");

                    b.ToTable("SurveyQuestion");
                });

            modelBuilder.Entity("CustomerFeedback.Models.SurveyResponse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Answer")
                        .HasColumnType("VARCHAR(2000)");

                    b.Property<int>("ContactId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<int?>("QuestionScore")
                        .HasColumnType("int");

                    b.Property<int?>("SurveyId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("SurveyResponseIteration")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.HasIndex("QuestionId");

                    b.HasIndex("SurveyId");

                    b.ToTable("SurveyResponse");
                });

            modelBuilder.Entity("CustomerFeedback.Models.Contact", b =>
                {
                    b.HasOne("CustomerFeedback.Models.Customer", "Customer")
                        .WithMany("Contacts")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("CustomerFeedback.Models.Survey", b =>
                {
                    b.HasOne("CustomerFeedback.Models.Administrator", "Administrator")
                        .WithMany("Surveys")
                        .HasForeignKey("AdministratorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Administrator");
                });

            modelBuilder.Entity("CustomerFeedback.Models.SurveyQuestion", b =>
                {
                    b.HasOne("CustomerFeedback.Models.Question", "Question")
                        .WithMany("SurveyQuestions")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CustomerFeedback.Models.Survey", "Survey")
                        .WithMany("SurveyQuestions")
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");

                    b.Navigation("Survey");
                });

            modelBuilder.Entity("CustomerFeedback.Models.SurveyResponse", b =>
                {
                    b.HasOne("CustomerFeedback.Models.Contact", "Contact")
                        .WithMany("SurveyResponses")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CustomerFeedback.Models.Question", "Question")
                        .WithMany("SurveyResponses")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CustomerFeedback.Models.Survey", "Survey")
                        .WithMany("SurveyResponses")
                        .HasForeignKey("SurveyId");

                    b.Navigation("Contact");

                    b.Navigation("Question");

                    b.Navigation("Survey");
                });

            modelBuilder.Entity("CustomerFeedback.Models.Administrator", b =>
                {
                    b.Navigation("Surveys");
                });

            modelBuilder.Entity("CustomerFeedback.Models.Contact", b =>
                {
                    b.Navigation("SurveyResponses");
                });

            modelBuilder.Entity("CustomerFeedback.Models.Customer", b =>
                {
                    b.Navigation("Contacts");
                });

            modelBuilder.Entity("CustomerFeedback.Models.Question", b =>
                {
                    b.Navigation("SurveyQuestions");

                    b.Navigation("SurveyResponses");
                });

            modelBuilder.Entity("CustomerFeedback.Models.Survey", b =>
                {
                    b.Navigation("SurveyQuestions");

                    b.Navigation("SurveyResponses");
                });
#pragma warning restore 612, 618
        }
    }
}
