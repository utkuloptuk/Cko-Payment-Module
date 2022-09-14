﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

#nullable disable

namespace Repository.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20220914205320_new-datas")]
    partial class newdatas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.Models.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CustomerId");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("TelephoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("953a2bdc-7aab-46fa-9364-8858424ca7db"),
                            Address = "new address1",
                            Age = 25,
                            CreationDate = new DateTime(2022, 9, 14, 23, 53, 20, 490, DateTimeKind.Local).AddTicks(9609),
                            Email = "email@example.com",
                            LastName = "lastname1",
                            Name = "newbie",
                            TelephoneNumber = "111111111",
                            UserType = 0
                        },
                        new
                        {
                            Id = new Guid("5314362a-5f87-4b38-9a88-1174d5999cc5"),
                            Address = "new address1",
                            Age = 25,
                            CreationDate = new DateTime(2022, 9, 14, 23, 53, 20, 490, DateTimeKind.Local).AddTicks(9628),
                            Email = "email2@example.com",
                            LastName = "lastname1",
                            Name = "employee",
                            TelephoneNumber = "22222222",
                            UserType = 1
                        },
                        new
                        {
                            Id = new Guid("f6db198c-8780-4687-b5f6-9aa2530c65eb"),
                            Address = "new address1",
                            Age = 25,
                            CreationDate = new DateTime(2022, 9, 14, 23, 53, 20, 490, DateTimeKind.Local).AddTicks(9633),
                            Email = "email3@example.com",
                            LastName = "lastname1",
                            Name = "affiliate",
                            TelephoneNumber = "33333333",
                            UserType = 2
                        },
                        new
                        {
                            Id = new Guid("0d23ac2f-3a5d-466d-8cc6-f8f3dab296c7"),
                            Address = "new address1",
                            Age = 25,
                            CreationDate = new DateTime(2020, 9, 14, 23, 53, 20, 490, DateTimeKind.Local).AddTicks(9636),
                            Email = "email4@example.com",
                            LastName = "lastname1",
                            Name = "veteran",
                            TelephoneNumber = "33333333",
                            UserType = 0
                        });
                });

            modelBuilder.Entity("Entities.Models.Invoice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("InvoiceId");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("GrossPrice")
                        .HasPrecision(10, 10)
                        .HasColumnType("decimal(10,10)");

                    b.Property<decimal>("NetPrice")
                        .HasPrecision(10, 10)
                        .HasColumnType("decimal(10,10)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Invoices", (string)null);
                });

            modelBuilder.Entity("Entities.Models.InvoiceDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("InvoiceDetailId");

                    b.Property<Guid>("InvoiceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("ProductId");

                    b.ToTable("InvoiceDetails", (string)null);
                });

            modelBuilder.Entity("Entities.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ProductId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasPrecision(5)
                        .HasColumnType("decimal(5,2)");

                    b.Property<int>("ProductType")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a22ac13b-e9aa-496a-8663-6c67a15ca2d9"),
                            Name = "product1",
                            Price = 10m,
                            ProductType = 4,
                            Quantity = 100,
                            UpdatedTime = new DateTime(2022, 9, 14, 23, 53, 20, 490, DateTimeKind.Local).AddTicks(9830)
                        },
                        new
                        {
                            Id = new Guid("807e4cf7-c336-43a5-a7b2-941f3de8b655"),
                            Name = "product2",
                            Price = 20m,
                            ProductType = 3,
                            Quantity = 50,
                            UpdatedTime = new DateTime(2022, 9, 14, 23, 53, 20, 490, DateTimeKind.Local).AddTicks(9836)
                        },
                        new
                        {
                            Id = new Guid("f715b188-178e-4108-bb62-946cddd3270d"),
                            Name = "product3",
                            Price = 30m,
                            ProductType = 1,
                            Quantity = 10,
                            UpdatedTime = new DateTime(2022, 9, 14, 23, 53, 20, 490, DateTimeKind.Local).AddTicks(9842)
                        },
                        new
                        {
                            Id = new Guid("03b49cd7-190a-4104-82c8-4fa23f928974"),
                            Name = "product4",
                            Price = 40m,
                            ProductType = 0,
                            Quantity = 2500,
                            UpdatedTime = new DateTime(2022, 9, 14, 23, 53, 20, 490, DateTimeKind.Local).AddTicks(9844)
                        },
                        new
                        {
                            Id = new Guid("a6fc2c2f-6cae-4db4-8901-4fc4987d1781"),
                            Name = "product5",
                            Price = 50m,
                            ProductType = 2,
                            Quantity = 5,
                            UpdatedTime = new DateTime(2022, 9, 14, 23, 53, 20, 490, DateTimeKind.Local).AddTicks(9846)
                        });
                });

            modelBuilder.Entity("Entities.Models.Invoice", b =>
                {
                    b.HasOne("Entities.Models.Customer", "Customers")
                        .WithMany("Invoices")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customers");
                });

            modelBuilder.Entity("Entities.Models.InvoiceDetail", b =>
                {
                    b.HasOne("Entities.Models.Invoice", "Invoices")
                        .WithMany("InvoiceDetails")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Product", "Products")
                        .WithMany("InvoiceDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoices");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("Entities.Models.Customer", b =>
                {
                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("Entities.Models.Invoice", b =>
                {
                    b.Navigation("InvoiceDetails");
                });

            modelBuilder.Entity("Entities.Models.Product", b =>
                {
                    b.Navigation("InvoiceDetails");
                });
#pragma warning restore 612, 618
        }
    }
}