﻿// <auto-generated />
using System;
using DeVLearninG.MyReservation.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;

namespace DeVLearninG.MyReservation.Domain.Migrations
{
    [DbContext(typeof(MyReservationContext))]
    [Migration("20200517220638_fks1")]
    partial class fks1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DeVLearninG.MyReservation.Domain.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("DeVLearninG.MyReservation.Domain.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(4000)")
                        .HasMaxLength(4000);

                    b.Property<int>("IdEventType")
                        .HasColumnType("int");

                    b.Property<Guid>("IdLocation")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("IdEventType");

                    b.HasIndex("IdLocation");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("DeVLearninG.MyReservation.Domain.EventType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("EventType");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Name = "FreeEvent"
                        },
                        new
                        {
                            Id = 1,
                            Name = "PaidEvent"
                        });
                });

            modelBuilder.Entity("DeVLearninG.MyReservation.Domain.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<Point>("Geoposition")
                        .IsRequired()
                        .HasColumnType("geography");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("DeVLearninG.MyReservation.Domain.Reservation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("EventId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdCustomer")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdEvent")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("IdCustomer");

                    b.ToTable("Reservation");
                });

            modelBuilder.Entity("DeVLearninG.MyReservation.Domain.Event", b =>
                {
                    b.HasOne("DeVLearninG.MyReservation.Domain.EventType", "EventType")
                        .WithMany()
                        .HasForeignKey("IdEventType")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DeVLearninG.MyReservation.Domain.Location", "Location")
                        .WithMany("Events")
                        .HasForeignKey("IdLocation")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DeVLearninG.MyReservation.Domain.Reservation", b =>
                {
                    b.HasOne("DeVLearninG.MyReservation.Domain.Event", "Event")
                        .WithMany("Reservations")
                        .HasForeignKey("EventId");

                    b.HasOne("DeVLearninG.MyReservation.Domain.Customer", "Customer")
                        .WithMany("Reservations")
                        .HasForeignKey("IdCustomer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
