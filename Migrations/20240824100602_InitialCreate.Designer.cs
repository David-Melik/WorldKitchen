﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorldKitchen.Data;

#nullable disable

namespace WorldKitchen.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240824100602_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("WorldKitchen.Models.DatabaseWorldKitchenCountry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Flag")
                        .HasColumnType("TEXT");

                    b.Property<string>("Map")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("WorldKitchen.Models.DatabaseWorldKitchenDishies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Allergen")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImagePreview")
                        .HasColumnType("TEXT");

                    b.Property<string>("IngredientList")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nutrition")
                        .HasColumnType("TEXT");

                    b.Property<string>("StepList")
                        .HasColumnType("TEXT");

                    b.Property<string>("Svg1")
                        .HasColumnType("TEXT");

                    b.Property<string>("Svg2")
                        .HasColumnType("TEXT");

                    b.Property<string>("Svg3")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Time")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Traduction")
                        .HasColumnType("TEXT");

                    b.Property<string>("Video")
                        .HasColumnType("TEXT");

                    b.Property<string>("VoiceName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Dishies");
                });
#pragma warning restore 612, 618
        }
    }
}
