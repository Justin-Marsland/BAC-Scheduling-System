﻿// <auto-generated />
using System;
using BACSchedulingSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BACSchedulingSystem.Migrations
{
    [DbContext(typeof(BACSchedulingSystemContext))]
    [Migration("20200326172220_Initial-Create")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BACSchedulingSystem.Models.Ingredient", b =>
                {
                    b.Property<string>("name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<short>("amount")
                        .HasColumnType("smallint");

                    b.Property<decimal>("cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("expDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("type")
                        .HasColumnType("int");

                    b.Property<string>("vendor")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("name");

                    b.ToTable("Ingredient");
                });
#pragma warning restore 612, 618
        }
    }
}