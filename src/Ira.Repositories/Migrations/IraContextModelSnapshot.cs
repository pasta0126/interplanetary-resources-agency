﻿// <auto-generated />
using System;
using Ira.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ira.Repositories.Migrations
{
    [DbContext(typeof(IraContext))]
    partial class IraContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Ira.Models.Entities.Crew", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Crew");
                });

            modelBuilder.Entity("Ira.Models.Entities.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AidCard")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompleteName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<Guid?>("CrewId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CrewId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("Ira.Models.Entities.Label", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MissionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("MissionId");

                    b.ToTable("Label");
                });

            modelBuilder.Entity("Ira.Models.Entities.Mission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<Guid?>("RouteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ShipId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RouteId");

                    b.HasIndex("ShipId");

                    b.ToTable("Mission");
                });

            modelBuilder.Entity("Ira.Models.Entities.Notification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<bool>("IsSentOk")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("MissionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("SentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Subject")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("MissionId");

                    b.ToTable("Notification");
                });

            modelBuilder.Entity("Ira.Models.Entities.Route", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CargoDescription")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<double>("CargoValue")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Destination")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Name")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Origin")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Route");
                });

            modelBuilder.Entity("Ira.Models.Entities.Ship", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CrewId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Type")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("CrewId");

                    b.ToTable("Ship");
                });

            modelBuilder.Entity("Ira.Models.Entities.Employee", b =>
                {
                    b.HasOne("Ira.Models.Entities.Crew", null)
                        .WithMany("Employees")
                        .HasForeignKey("CrewId");
                });

            modelBuilder.Entity("Ira.Models.Entities.Label", b =>
                {
                    b.HasOne("Ira.Models.Entities.Mission", null)
                        .WithMany("Labels")
                        .HasForeignKey("MissionId");
                });

            modelBuilder.Entity("Ira.Models.Entities.Mission", b =>
                {
                    b.HasOne("Ira.Models.Entities.Route", "Route")
                        .WithMany()
                        .HasForeignKey("RouteId");

                    b.HasOne("Ira.Models.Entities.Ship", "Ship")
                        .WithMany()
                        .HasForeignKey("ShipId");

                    b.Navigation("Route");

                    b.Navigation("Ship");
                });

            modelBuilder.Entity("Ira.Models.Entities.Notification", b =>
                {
                    b.HasOne("Ira.Models.Entities.Mission", null)
                        .WithMany("Notifications")
                        .HasForeignKey("MissionId");
                });

            modelBuilder.Entity("Ira.Models.Entities.Ship", b =>
                {
                    b.HasOne("Ira.Models.Entities.Crew", "Crew")
                        .WithMany()
                        .HasForeignKey("CrewId");

                    b.Navigation("Crew");
                });

            modelBuilder.Entity("Ira.Models.Entities.Crew", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Ira.Models.Entities.Mission", b =>
                {
                    b.Navigation("Labels");

                    b.Navigation("Notifications");
                });
#pragma warning restore 612, 618
        }
    }
}
