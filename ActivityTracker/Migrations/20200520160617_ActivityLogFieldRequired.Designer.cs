﻿// <auto-generated />
using System;
using ActivityTracker.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ActivityTracker.Migrations
{
    [DbContext(typeof(ActivityTrackerContext))]
    [Migration("20200520160617_ActivityLogFieldRequired")]
    partial class ActivityLogFieldRequired
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ActivityTracker.Models.Activity", b =>
                {
                    b.Property<int>("ActivityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActivityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("ActivityValidFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ActivityValidTo")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CustomUnitId")
                        .HasColumnType("int");

                    b.Property<decimal>("MaxPointsPerDay")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PointsPerUnit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("UnitId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("ActivityId");

                    b.HasIndex("CustomUnitId");

                    b.HasIndex("UnitId");

                    b.ToTable("Activity");
                });

            modelBuilder.Entity("ActivityTracker.Models.ActivityLog", b =>
                {
                    b.Property<int>("ActivityLogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActivityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LogDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalPoints")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Units")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("ActivityLogId");

                    b.HasIndex("ActivityId");

                    b.ToTable("ActivityLog");
                });

            modelBuilder.Entity("ActivityTracker.Models.CustomUnit", b =>
                {
                    b.Property<int>("CustomUnitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomUnitName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomUnitId");

                    b.ToTable("CustomUnit");
                });

            modelBuilder.Entity("ActivityTracker.Models.Unit", b =>
                {
                    b.Property<int>("UnitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UnitName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("UnitId");

                    b.ToTable("Unit");
                });

            modelBuilder.Entity("ActivityTracker.Models.Activity", b =>
                {
                    b.HasOne("ActivityTracker.Models.CustomUnit", "CustomUnit")
                        .WithMany("Activities")
                        .HasForeignKey("CustomUnitId");

                    b.HasOne("ActivityTracker.Models.Unit", "Unit")
                        .WithMany("Activities")
                        .HasForeignKey("UnitId");
                });

            modelBuilder.Entity("ActivityTracker.Models.ActivityLog", b =>
                {
                    b.HasOne("ActivityTracker.Models.Activity", "Activity")
                        .WithMany("ActivityLogs")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
