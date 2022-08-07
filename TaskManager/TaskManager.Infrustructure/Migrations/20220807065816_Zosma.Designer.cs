﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskManager.Infrustructure.DbContexts;

#nullable disable

namespace TaskManager.Infrustructure.Migrations
{
    [DbContext(typeof(TaskManagerContext))]
    [Migration("20220807065816_Zosma")]
    partial class Zosma
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TaskManager.Domain.Activity", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Client")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Task1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Task2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Task3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Task4")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Task5")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Activities");
                });
#pragma warning restore 612, 618
        }
    }
}
