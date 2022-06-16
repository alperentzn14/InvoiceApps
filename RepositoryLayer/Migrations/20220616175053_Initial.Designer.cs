﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RepositoryLayer;

#nullable disable

namespace RepositoryLayer.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220616175053_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CoreLayer.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Customers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Adress = "İstanbul",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Alperen",
                            PhoneNumber = "5456030503",
                            Surname = "Tüzün"
                        },
                        new
                        {
                            Id = 2,
                            Adress = "Adana",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "test",
                            PhoneNumber = "545603033",
                            Surname = "testt"
                        },
                        new
                        {
                            Id = 3,
                            Adress = "Bursa",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "test2",
                            PhoneNumber = "545603222",
                            Surname = "test22"
                        });
                });

            modelBuilder.Entity("CoreLayer.Models.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.ToTable("Invoices", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 1,
                            ProductId = 1,
                            Quantity = 2,
                            Total = 200m
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 2,
                            ProductId = 2,
                            Quantity = 2,
                            Total = 400m
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 3,
                            ProductId = 3,
                            Quantity = 3,
                            Total = 900m
                        });
                });

            modelBuilder.Entity("CoreLayer.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Products", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 1,
                            Name = "product 1",
                            Price = 100m
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 2,
                            Name = "prodcut 2",
                            Price = 200m
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 3,
                            Name = "prodcut 3",
                            Price = 300m
                        });
                });

            modelBuilder.Entity("CoreLayer.Models.Invoice", b =>
                {
                    b.HasOne("CoreLayer.Models.Customer", "Customer")
                        .WithMany("Invoices")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoreLayer.Models.Product", "Product")
                        .WithMany("Invoices")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("CoreLayer.Models.Product", b =>
                {
                    b.HasOne("CoreLayer.Models.Customer", "Customer")
                        .WithMany("Products")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("CoreLayer.Models.Customer", b =>
                {
                    b.Navigation("Invoices");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("CoreLayer.Models.Product", b =>
                {
                    b.Navigation("Invoices");
                });
#pragma warning restore 612, 618
        }
    }
}