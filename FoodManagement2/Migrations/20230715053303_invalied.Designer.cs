﻿// <auto-generated />
using FoodManagement2.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FoodManagement2.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230715053303_invalied")]
    partial class invalied
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FoodManagement2.Models.Customer", b =>
                {
                    b.Property<int>("C_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("C_ID"), 1L, 1);

                    b.Property<string>("C_NAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MOBILE")
                        .HasColumnType("int");

                    b.HasKey("C_ID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("FoodManagement2.Models.Food", b =>
                {
                    b.Property<int>("F_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("F_ID"), 1L, 1);

                    b.Property<string>("IMAGE")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PRICE")
                        .HasColumnType("int");

                    b.Property<int>("QTY")
                        .HasColumnType("int");

                    b.HasKey("F_ID");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("FoodManagement2.Models.Order", b =>
                {
                    b.Property<int>("O_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("O_ID"), 1L, 1);

                    b.Property<int>("C_ID")
                        .HasColumnType("int");

                    b.Property<int>("F_ID")
                        .HasColumnType("int");

                    b.Property<int>("ORDER_QTY")
                        .HasColumnType("int");

                    b.Property<int>("PRICE")
                        .HasColumnType("int");

                    b.HasKey("O_ID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("FoodManagement2.Models.User", b =>
                {
                    b.Property<int>("U_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("U_ID"), 1L, 1);

                    b.Property<string>("U_NAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("U_PASSWORD")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("U_ID");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
