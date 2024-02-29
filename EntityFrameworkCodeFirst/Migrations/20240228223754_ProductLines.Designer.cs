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
    [Migration("20240228223754_ProductLines")]
    partial class ProductLines
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

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
#pragma warning restore 612, 618
        }
    }
}
