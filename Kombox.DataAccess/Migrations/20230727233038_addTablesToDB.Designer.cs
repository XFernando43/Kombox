﻿// <auto-generated />
using Kombox.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kombox.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230727233038_addTablesToDB")]
    partial class addTablesToDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Kombox.Models.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("CategoryId");

                    b.ToTable("categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            DisplayOrder = 10,
                            Name = "Action"
                        },
                        new
                        {
                            CategoryId = 2,
                            DisplayOrder = 10,
                            Name = "Action"
                        },
                        new
                        {
                            CategoryId = 3,
                            DisplayOrder = 10,
                            Name = "Action"
                        });
                });

            modelBuilder.Entity("Kombox.Models.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ListPrice")
                        .HasColumnType("float");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double>("Price100")
                        .HasColumnType("float");

                    b.Property<double>("Price50")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Author = "Billy Spark",
                            CategoryId = 1,
                            Description = "Present vitae sodales. Praesent molesting agousting disgunting Auhting",
                            ISBN = "SWD9999001",
                            ImageUrl = "",
                            ListPrice = 99.0,
                            Price = 90.0,
                            Price100 = 100.0,
                            Price50 = 80.0,
                            Title = "Fortune of Time"
                        },
                        new
                        {
                            ProductId = 2,
                            Author = "Roberto Gomez Bolaños",
                            CategoryId = 1,
                            Description = "Present the short life from a litle child who lives in a small hometown",
                            ISBN = "SWD9999002",
                            ImageUrl = "",
                            ListPrice = 99.0,
                            Price = 90.0,
                            Price100 = 100.0,
                            Price50 = 80.0,
                            Title = "Diary of Chavo"
                        });
                });

            modelBuilder.Entity("Kombox.Models.Models.Product", b =>
                {
                    b.HasOne("Kombox.Models.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
