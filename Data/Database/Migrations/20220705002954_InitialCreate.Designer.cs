﻿// <auto-generated />
using System;
using GrpcHighscoreService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GrpcHighscoreService.Data.Database.Migrations
{
    [DbContext(typeof(HighscoreContext))]
    [Migration("20220705002954_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.6");

            modelBuilder.Entity("GrpcHighscoreService.Data.Models.Score", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("PlayerName")
                        .HasColumnType("TEXT");

                    b.Property<int>("Points")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("TimeCreated")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Scores");
                });
#pragma warning restore 612, 618
        }
    }
}
