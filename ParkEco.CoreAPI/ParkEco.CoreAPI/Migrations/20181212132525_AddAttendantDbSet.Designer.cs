﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParkEco.CoreAPI.Data;

namespace ParkEco.CoreAPI.Migrations
{
    [DbContext(typeof(ParkingEcoServerContext))]
    [Migration("20181212132525_AddAttendantDbSet")]
    partial class AddAttendantDbSet
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ParkEco.CoreAPI.Data.Models.ParkingLot", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Description");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("ParkingLots");
                });

            modelBuilder.Entity("ParkEco.CoreAPI.Data.Models.ParkingLotAttendant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("ParkingLotAttendants");
                });

            modelBuilder.Entity("ParkEco.CoreAPI.Data.Models.Session", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("From");

                    b.Property<Guid>("ParkingLotId");

                    b.Property<DateTime>("To");

                    b.HasKey("Id");

                    b.HasIndex("ParkingLotId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("ParkEco.CoreAPI.Data.Models.Ticket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsReturned");

                    b.Property<bool>("IsValid");

                    b.Property<Guid>("ParkingLotAttendantId");

                    b.Property<string>("Plate");

                    b.Property<Guid>("SessionId");

                    b.HasKey("Id");

                    b.HasIndex("ParkingLotAttendantId");

                    b.HasIndex("SessionId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("ParkEco.CoreAPI.Data.Models.Session", b =>
                {
                    b.HasOne("ParkEco.CoreAPI.Data.Models.ParkingLot", "ParkingLot")
                        .WithMany("Sessions")
                        .HasForeignKey("ParkingLotId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ParkEco.CoreAPI.Data.Models.Ticket", b =>
                {
                    b.HasOne("ParkEco.CoreAPI.Data.Models.ParkingLotAttendant", "ParkingLotAttendant")
                        .WithMany("Tickets")
                        .HasForeignKey("ParkingLotAttendantId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ParkEco.CoreAPI.Data.Models.Session", "Session")
                        .WithMany("Tickets")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
