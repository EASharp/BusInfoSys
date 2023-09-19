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
    [Migration("20230917054937_strRoute")]
    partial class strRoute
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
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

                    b.Property<string>("BusNum")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("DriverId")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

                    b.Property<bool>("Enabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Latitude")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Longitude")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("RouteNum")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("BusNum");

                    b.HasIndex("RouteNum");

                    b.ToTable("Buses");
                });

            modelBuilder.Entity("BusInfo.Core.Classes.Driver", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

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
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

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

            modelBuilder.Entity("BusInfo.Core.Classes.Route", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Route");
                });

            modelBuilder.Entity("PlaceRoute", b =>
                {
                    b.Property<string>("PlacesId")
                        .HasColumnType("varchar(40)");

                    b.Property<string>("RouteId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("PlacesId", "RouteId");

                    b.HasIndex("RouteId");

                    b.ToTable("PlaceRoute");
                });

            modelBuilder.Entity("PlaceRoute", b =>
                {
                    b.HasOne("BusInfo.Core.Classes.Place", null)
                        .WithMany()
                        .HasForeignKey("PlacesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusInfo.Core.Classes.Route", null)
                        .WithMany()
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}