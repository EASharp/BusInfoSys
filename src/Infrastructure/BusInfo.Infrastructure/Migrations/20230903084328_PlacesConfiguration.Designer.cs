﻿// <auto-generated />
using BusInfo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BusInfo.Infrastructure.Migrations
{
    [DbContext(typeof(AppDb))]
    [Migration("20230903084328_PlacesConfiguration")]
    partial class PlacesConfiguration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BusInfo.Core.Classes.Bus", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("BusNum")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("DriverId")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<bool>("Enabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Latitude")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Longitude")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("RouteNum")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BusNum");

                    b.HasIndex("RouteNum");

                    b.ToTable("Buses");
                });

            modelBuilder.Entity("BusInfo.Core.Classes.Driver", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("DriverLogin")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DriverName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DriverPassword")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DriverSurname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("BusInfo.Core.Classes.Place", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("Latitude")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Longitude")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PlaceName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("BusPlace", b =>
                {
                    b.Property<string>("BusId")
                        .HasColumnType("varchar(32)");

                    b.Property<string>("PlacesId")
                        .HasColumnType("varchar(32)");

                    b.HasKey("BusId", "PlacesId");

                    b.HasIndex("PlacesId");

                    b.ToTable("BusPlace");
                });

            modelBuilder.Entity("BusPlace", b =>
                {
                    b.HasOne("BusInfo.Core.Classes.Bus", null)
                        .WithMany()
                        .HasForeignKey("BusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusInfo.Core.Classes.Place", null)
                        .WithMany()
                        .HasForeignKey("PlacesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
