﻿// <auto-generated />
using System;
using EntityFrameworkCodeFirst.MODEL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EntityFrameworkCodeFirst.Migrations
{
    [DbContext(typeof(BusinessDBContext))]
    [Migration("20240228231612_Employees")]
    partial class Employees
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EntityFrameworkCodeFirst.MODEL.Employee", b =>
                {
                    b.Property<int>("employeeNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("extension")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("jobTitle")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("officeCode")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<int?>("reportsTo")
                        .HasColumnType("int");

                    b.HasKey("employeeNumber");

                    b.HasIndex("officeCode");

                    b.HasIndex("reportsTo");

                    b.ToTable("employees");
                });

            modelBuilder.Entity("EntityFrameworkCodeFirst.MODEL.Office", b =>
                {
                    b.Property<string>("officeCode")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("addressLine1")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("addressLine2")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("country")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("postalCode")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<string>("state")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("territory")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("officeCode");

                    b.ToTable("offices");
                });

            modelBuilder.Entity("EntityFrameworkCodeFirst.MODEL.Product", b =>
                {
                    b.Property<string>("productCode")
                        .HasColumnType("varchar(15)");

                    b.Property<decimal>("BuyPrice")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("MSRP")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("productDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("productLine")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("productName")
                        .IsRequired()
                        .HasColumnType("varchar(70)");

                    b.Property<string>("productScale")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("productVendor")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<short>("quantityInStock")
                        .HasColumnType("smallint(6)");

                    b.HasKey("productCode");

                    b.HasIndex("productLine");

                    b.ToTable("products");
                });

            modelBuilder.Entity("EntityFrameworkCodeFirst.MODEL.ProductLine", b =>
                {
                    b.Property<string>("productLine")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("htmlDescription")
                        .HasColumnType("mediumtext");

                    b.Property<byte[]>("image")
                        .HasColumnType("mediumblob");

                    b.Property<string>("textDescription")
                        .HasColumnType("varchar(4000)");

                    b.HasKey("productLine");

                    b.ToTable("productlines");
                });

            modelBuilder.Entity("EntityFrameworkCodeFirst.MODEL.Employee", b =>
                {
                    b.HasOne("EntityFrameworkCodeFirst.MODEL.Office", "offices")
                        .WithMany()
                        .HasForeignKey("officeCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityFrameworkCodeFirst.MODEL.Employee", "ReportsToRef")
                        .WithMany()
                        .HasForeignKey("reportsTo");
                });

            modelBuilder.Entity("EntityFrameworkCodeFirst.MODEL.Product", b =>
                {
                    b.HasOne("EntityFrameworkCodeFirst.MODEL.ProductLine", "ProductLines")
                        .WithMany()
                        .HasForeignKey("productLine")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
