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
    [Migration("20200427112654_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BACSchedulingSystem.Models.Equipment", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("QuantityReserved")
                        .HasColumnType("int");

                    b.HasKey("Name");

                    b.ToTable("Equipment");
                });

            modelBuilder.Entity("BACSchedulingSystem.Models.Ingredient", b =>
                {
                    b.Property<string>("name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RecipeName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<short>("amount")
                        .HasColumnType("smallint");

                    b.Property<decimal>("cost")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime>("expDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("type")
                        .HasColumnType("int");

                    b.Property<string>("vendor")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("name");

                    b.HasIndex("RecipeName");

                    b.ToTable("Ingredient");
                });

            modelBuilder.Entity("BACSchedulingSystem.Models.Login", b =>
                {
                    b.Property<string>("email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("email");

                    b.ToTable("Login");
                });

            modelBuilder.Entity("BACSchedulingSystem.Models.Recipe", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("CookingInstructions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("GlutenFree")
                        .HasColumnType("bit");

                    b.Property<bool>("Vegan")
                        .HasColumnType("bit");

                    b.Property<bool>("Vegetarian")
                        .HasColumnType("bit");

                    b.HasKey("Name");

                    b.ToTable("Recipe");
                });

            modelBuilder.Entity("BACSchedulingSystem.Models.Ingredient", b =>
                {
                    b.HasOne("BACSchedulingSystem.Models.Recipe", null)
                        .WithMany("IngredientList")
                        .HasForeignKey("RecipeName");
                });
#pragma warning restore 612, 618
        }
    }
}
