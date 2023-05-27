﻿// <auto-generated />
using System;
using EFCDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EFCDataAccess.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230527215628_MeasurmentsTimezone3")]
    partial class MeasurmentsTimezone3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Model.IOTDevice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("IOTDevices");
                });

            modelBuilder.Entity("Model.Measurement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Co2")
                        .HasColumnType("integer");

                    b.Property<int?>("DeviceId")
                        .HasColumnType("integer");

                    b.Property<int>("Humidity")
                        .HasColumnType("integer");

                    b.Property<int>("ServoStatus")
                        .HasColumnType("integer");

                    b.Property<int>("Temperature")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Time")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.ToTable("Measurements");
                });

            modelBuilder.Entity("Model.Preset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("DeviceId")
                        .HasColumnType("integer");

                    b.Property<int>("MaxCo2")
                        .HasColumnType("integer");

                    b.Property<int>("MaxHumidity")
                        .HasColumnType("integer");

                    b.Property<int>("MaxTemperature")
                        .HasColumnType("integer");

                    b.Property<int>("MinCo2")
                        .HasColumnType("integer");

                    b.Property<int>("MinHumidity")
                        .HasColumnType("integer");

                    b.Property<int>("MinTemperature")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Servo")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.ToTable("Presets");
                });

            modelBuilder.Entity("Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Model.IOTDevice", b =>
                {
                    b.HasOne("Model.User", "User")
                        .WithMany("IOTDevices")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Model.Measurement", b =>
                {
                    b.HasOne("Model.IOTDevice", "Device")
                        .WithMany("Measurements")
                        .HasForeignKey("DeviceId");

                    b.Navigation("Device");
                });

            modelBuilder.Entity("Model.Preset", b =>
                {
                    b.HasOne("Model.IOTDevice", "Device")
                        .WithMany("Presets")
                        .HasForeignKey("DeviceId");

                    b.Navigation("Device");
                });

            modelBuilder.Entity("Model.IOTDevice", b =>
                {
                    b.Navigation("Measurements");

                    b.Navigation("Presets");
                });

            modelBuilder.Entity("Model.User", b =>
                {
                    b.Navigation("IOTDevices");
                });
#pragma warning restore 612, 618
        }
    }
}
