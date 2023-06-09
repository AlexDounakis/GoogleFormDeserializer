﻿// <auto-generated />
using System;
using GoogleFormDeserializer.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GoogleFormDeserializer.Migrations
{
    [DbContext(typeof(GoogleFormsDbContext))]
    [Migration("20230409170003_init5")]
    partial class init5
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Answer", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("correctAnswersId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("correctAnswersId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("ChoiceQuestion", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("questionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("questionId")
                        .IsUnique();

                    b.ToTable("ChoiceQuestions");
                });

            modelBuilder.Entity("CorrectAnswers", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("gradingId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id");

                    b.HasIndex("gradingId")
                        .IsUnique();

                    b.ToTable("CorrectAnswers");
                });

            modelBuilder.Entity("Form", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("formId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasAnnotation("Relational:JsonPropertyName", "formId");

                    b.Property<string>("responderUri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("revisionId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasAlternateKey("formId");

                    b.ToTable("Forms");
                });

            modelBuilder.Entity("Grading", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("pointValue")
                        .HasColumnType("int");

                    b.Property<Guid>("questionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id");

                    b.HasIndex("questionId")
                        .IsUnique();

                    b.ToTable("Gradings");
                });

            modelBuilder.Entity("Image", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("contentUri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("imageItemId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id");

                    b.HasIndex("imageItemId")
                        .IsUnique();

                    b.ToTable("Images");
                });

            modelBuilder.Entity("ImageItem", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("itemId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id");

                    b.HasIndex("itemId")
                        .IsUnique();

                    b.ToTable("ImageItems");
                });

            modelBuilder.Entity("Info", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("documentTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("formId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("formId")
                        .IsUnique();

                    b.ToTable("Info");
                });

            modelBuilder.Entity("Item", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("formId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("itemId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("formId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Option", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("choiceQuestionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("choiceQuestionId");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("Properties", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("alignment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("imageId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id");

                    b.HasIndex("imageId")
                        .IsUnique();

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("Question", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("questionId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("questionItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("required")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.HasIndex("questionItemId")
                        .IsUnique();

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("QuestionItem", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("itemId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id");

                    b.HasIndex("itemId")
                        .IsUnique();

                    b.ToTable("QuestionItems");
                });

            modelBuilder.Entity("QuizSettings", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("isQuiz")
                        .HasColumnType("bit");

                    b.Property<Guid>("settingsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id");

                    b.HasIndex("settingsId")
                        .IsUnique();

                    b.ToTable("QuizSettings");
                });

            modelBuilder.Entity("Settings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("formId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("formId")
                        .IsUnique();

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("Answer", b =>
                {
                    b.HasOne("CorrectAnswers", "correctAnswers")
                        .WithMany("answers")
                        .HasForeignKey("correctAnswersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("correctAnswers");
                });

            modelBuilder.Entity("ChoiceQuestion", b =>
                {
                    b.HasOne("Question", "question")
                        .WithOne("choiceQuestion")
                        .HasForeignKey("ChoiceQuestion", "questionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("question");
                });

            modelBuilder.Entity("CorrectAnswers", b =>
                {
                    b.HasOne("Grading", "grading")
                        .WithOne("correctAnswers")
                        .HasForeignKey("CorrectAnswers", "gradingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("grading");
                });

            modelBuilder.Entity("Grading", b =>
                {
                    b.HasOne("Question", "question")
                        .WithOne("grading")
                        .HasForeignKey("Grading", "questionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("question");
                });

            modelBuilder.Entity("Image", b =>
                {
                    b.HasOne("ImageItem", "imageItem")
                        .WithOne("image")
                        .HasForeignKey("Image", "imageItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("imageItem");
                });

            modelBuilder.Entity("ImageItem", b =>
                {
                    b.HasOne("Item", "item")
                        .WithOne("imageItem")
                        .HasForeignKey("ImageItem", "itemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("item");
                });

            modelBuilder.Entity("Info", b =>
                {
                    b.HasOne("Form", "form")
                        .WithOne("info")
                        .HasForeignKey("Info", "formId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("form");
                });

            modelBuilder.Entity("Item", b =>
                {
                    b.HasOne("Form", "form")
                        .WithMany("items")
                        .HasForeignKey("formId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("form");
                });

            modelBuilder.Entity("Option", b =>
                {
                    b.HasOne("ChoiceQuestion", "choiceQuestion")
                        .WithMany("options")
                        .HasForeignKey("choiceQuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("choiceQuestion");
                });

            modelBuilder.Entity("Properties", b =>
                {
                    b.HasOne("Image", "image")
                        .WithOne("properties")
                        .HasForeignKey("Properties", "imageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("image");
                });

            modelBuilder.Entity("Question", b =>
                {
                    b.HasOne("QuestionItem", "questionItem")
                        .WithOne("question")
                        .HasForeignKey("Question", "questionItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("questionItem");
                });

            modelBuilder.Entity("QuestionItem", b =>
                {
                    b.HasOne("Item", "item")
                        .WithOne("questionItem")
                        .HasForeignKey("QuestionItem", "itemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("item");
                });

            modelBuilder.Entity("QuizSettings", b =>
                {
                    b.HasOne("Settings", "setting")
                        .WithOne("quizSettings")
                        .HasForeignKey("QuizSettings", "settingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("setting");
                });

            modelBuilder.Entity("Settings", b =>
                {
                    b.HasOne("Form", "form")
                        .WithOne("settings")
                        .HasForeignKey("Settings", "formId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("form");
                });

            modelBuilder.Entity("ChoiceQuestion", b =>
                {
                    b.Navigation("options");
                });

            modelBuilder.Entity("CorrectAnswers", b =>
                {
                    b.Navigation("answers");
                });

            modelBuilder.Entity("Form", b =>
                {
                    b.Navigation("info")
                        .IsRequired();

                    b.Navigation("items");

                    b.Navigation("settings")
                        .IsRequired();
                });

            modelBuilder.Entity("Grading", b =>
                {
                    b.Navigation("correctAnswers")
                        .IsRequired();
                });

            modelBuilder.Entity("Image", b =>
                {
                    b.Navigation("properties")
                        .IsRequired();
                });

            modelBuilder.Entity("ImageItem", b =>
                {
                    b.Navigation("image")
                        .IsRequired();
                });

            modelBuilder.Entity("Item", b =>
                {
                    b.Navigation("imageItem")
                        .IsRequired();

                    b.Navigation("questionItem")
                        .IsRequired();
                });

            modelBuilder.Entity("Question", b =>
                {
                    b.Navigation("choiceQuestion")
                        .IsRequired();

                    b.Navigation("grading")
                        .IsRequired();
                });

            modelBuilder.Entity("QuestionItem", b =>
                {
                    b.Navigation("question")
                        .IsRequired();
                });

            modelBuilder.Entity("Settings", b =>
                {
                    b.Navigation("quizSettings")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
