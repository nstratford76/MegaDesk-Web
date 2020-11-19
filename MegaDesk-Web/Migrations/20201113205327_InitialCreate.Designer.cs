﻿// <auto-generated />
using System;
using MegaDesk_Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MegaDesk_Web.Migrations
{
    [DbContext(typeof(MegaDesk_WebContext))]
    [Migration("20201113205327_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MegaDesk_Web.Models.Desk", b =>
                {
                    b.Property<int>("DeskID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Area")
                        .HasColumnType("int");

                    b.Property<int>("AreaCost")
                        .HasColumnType("int");

                    b.Property<int>("Depth")
                        .HasColumnType("int");

                    b.Property<int>("MaterialCost")
                        .HasColumnType("int");

                    b.Property<int>("NumberofDrawers")
                        .HasColumnType("int");

                    b.Property<int>("NumberofDrawersCost")
                        .HasColumnType("int");

                    b.Property<int>("SurfaceMaterial")
                        .HasColumnType("int");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("DeskID");

                    b.ToTable("Desk");
                });

            modelBuilder.Entity("MegaDesk_Web.Models.DeskQuote", b =>
                {
                    b.Property<int>("DeskQuoteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DeskID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumDeskCost")
                        .HasColumnType("int");

                    b.Property<int>("NumDesks")
                        .HasColumnType("int");

                    b.Property<string>("Shipping")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("ShippingCost")
                        .HasColumnType("real");

                    b.Property<float>("totalCost")
                        .HasColumnType("real");

                    b.HasKey("DeskQuoteID");

                    b.HasIndex("DeskID");

                    b.ToTable("DeskQuote");
                });

            modelBuilder.Entity("MegaDesk_Web.Models.DeskQuote", b =>
                {
                    b.HasOne("MegaDesk_Web.Models.Desk", "D")
                        .WithMany()
                        .HasForeignKey("DeskID");
                });
#pragma warning restore 612, 618
        }
    }
}
