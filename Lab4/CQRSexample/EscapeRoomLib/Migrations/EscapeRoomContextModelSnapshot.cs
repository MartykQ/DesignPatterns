﻿// <auto-generated />
using System;
using EscapeRoom_CQRS.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EscapeRoom_CQRS.Migrations
{
    [DbContext(typeof(EscapeRoomContext))]
    partial class EscapeRoomContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0-preview.2.20120.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EscapeRoom_CQRS.Models.Read.ReservationView", b =>
                {
                    b.Property<Guid>("ReservationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PlayerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReservationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RoomName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ReservationId");

                    b.ToTable("ReservationViews");

                    b.HasCheckConstraint("CK_ReservationViews_Status_Enum_Constraint", "[Status] IN(0, 1, 3, 4)");
                });

            modelBuilder.Entity("EscapeRoom_CQRS.Models.Read.VisitView", b =>
                {
                    b.Property<Guid>("VisitId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EnterDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ExitDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PlayerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RoomName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("VisitId");

                    b.ToTable("VisitViews");
                });

            modelBuilder.Entity("EscapeRoom_CQRS.Models.Write.Player", b =>
                {
                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("PlayerId");

                    b.ToTable("Players");

                    b.HasCheckConstraint("CK_Players_Status_Enum_Constraint", "[Status] IN(0, 1)");
                });

            modelBuilder.Entity("EscapeRoom_CQRS.Models.Write.Reservation", b =>
                {
                    b.Property<Guid>("ReservationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ReservationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("VisitId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ReservationId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("RoomId");

                    b.HasIndex("VisitId");

                    b.ToTable("Reservations");

                    b.HasCheckConstraint("CK_Reservations_Status_Enum_Constraint", "[Status] IN(0, 1, 3, 4)");
                });

            modelBuilder.Entity("EscapeRoom_CQRS.Models.Write.Room", b =>
                {
                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("RoomId");

                    b.ToTable("Rooms");

                    b.HasCheckConstraint("CK_Rooms_Level_Enum_Constraint", "[Level] IN(0, 1, 2)");

                    b.HasCheckConstraint("CK_Rooms_Status_Enum_Constraint", "[Status] IN(0, 1, 2)");
                });

            modelBuilder.Entity("EscapeRoom_CQRS.Models.Write.Visit", b =>
                {
                    b.Property<Guid>("VisitId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EnterDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ExitDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ReservationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("VisitId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("ReservationId")
                        .IsUnique()
                        .HasFilter("[ReservationId] IS NOT NULL");

                    b.HasIndex("RoomId");

                    b.ToTable("Visits");
                });

            modelBuilder.Entity("EscapeRoom_CQRS.Models.Write.Reservation", b =>
                {
                    b.HasOne("EscapeRoom_CQRS.Models.Write.Player", "Player")
                        .WithMany("Reservations")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EscapeRoom_CQRS.Models.Write.Room", "Room")
                        .WithMany("Reservations")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EscapeRoom_CQRS.Models.Write.Visit", "Visit")
                        .WithMany()
                        .HasForeignKey("VisitId");
                });

            modelBuilder.Entity("EscapeRoom_CQRS.Models.Write.Visit", b =>
                {
                    b.HasOne("EscapeRoom_CQRS.Models.Write.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EscapeRoom_CQRS.Models.Write.Reservation", "Reservation")
                        .WithOne()
                        .HasForeignKey("EscapeRoom_CQRS.Models.Write.Visit", "ReservationId");

                    b.HasOne("EscapeRoom_CQRS.Models.Write.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
