﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Waitingway.Server;

#nullable disable

namespace Waitingway.Server.Migrations
{
    [DbContext(typeof(WaitingwayContext))]
    [Migration("20220113034842_AddVersionToQueueSession")]
    partial class AddVersionToQueueSession
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Waitingway.Server.Models.QueueSession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uuid");

                    b.Property<string>("ClientSessionId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("DataCenter")
                        .HasColumnType("integer");

                    b.Property<int?>("DutyContentId")
                        .HasColumnType("integer");

                    b.Property<string>("PluginVersion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SessionType")
                        .HasColumnType("integer");

                    b.Property<int?>("World")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DataCenter", "World");

                    b.ToTable("QueueSessions");
                });

            modelBuilder.Entity("Waitingway.Server.Models.QueueSessionData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("EndReason")
                        .HasColumnType("integer");

                    b.Property<TimeSpan?>("GameTimeEstimate")
                        .HasColumnType("interval");

                    b.Property<TimeSpan?>("OurTimeEstimate")
                        .HasColumnType("interval");

                    b.Property<long?>("QueuePosition")
                        .HasColumnType("bigint");

                    b.Property<int>("SessionId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Time")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SessionId");

                    b.HasIndex("Time", "Type");

                    b.ToTable("QueueSessionData");
                });

            modelBuilder.Entity("Waitingway.Server.Models.QueueSessionData", b =>
                {
                    b.HasOne("Waitingway.Server.Models.QueueSession", "Session")
                        .WithMany("DataPoints")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Session");
                });

            modelBuilder.Entity("Waitingway.Server.Models.QueueSession", b =>
                {
                    b.Navigation("DataPoints");
                });
#pragma warning restore 612, 618
        }
    }
}
