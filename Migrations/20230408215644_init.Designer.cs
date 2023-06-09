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
    [Migration("20230408215644_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("formId");

                    b.ToTable("Item");
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

            modelBuilder.Entity("Settings", b =>
                {
                    b.HasOne("Form", "form")
                        .WithOne("settings")
                        .HasForeignKey("Settings", "formId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("form");
                });

            modelBuilder.Entity("Form", b =>
                {
                    b.Navigation("info")
                        .IsRequired();

                    b.Navigation("items");

                    b.Navigation("settings")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
