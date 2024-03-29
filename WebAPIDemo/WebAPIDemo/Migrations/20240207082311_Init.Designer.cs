﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPIDemo.data;

#nullable disable

namespace WebAPIDemo.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240207082311_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebAPIDemo.Models.Shirts.Shirt", b =>
                {
                    b.Property<int>("ShirtId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShirtId"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int?>("Size")
                        .HasColumnType("int");

                    b.HasKey("ShirtId");

                    b.ToTable("Shirts");

                    b.HasData(
                        new
                        {
                            ShirtId = 1,
                            Brand = "My Brand",
                            Color = "Blue",
                            Gender = "Men",
                            Price = 50
                        },
                        new
                        {
                            ShirtId = 2,
                            Brand = "My Brand",
                            Color = "Blue",
                            Gender = "Men",
                            Price = 50
                        },
                        new
                        {
                            ShirtId = 3,
                            Brand = "My Brand",
                            Color = "Blue",
                            Gender = "Men",
                            Price = 50
                        },
                        new
                        {
                            ShirtId = 4,
                            Brand = "My Brand",
                            Color = "Blue",
                            Gender = "Men",
                            Price = 50
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
