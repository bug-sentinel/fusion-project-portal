﻿// <auto-generated />
using System;
using Equinor.ProjectExecutionPortal.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Equinor.ProjectExecutionPortal.Infrastructure.Migrations
{
    [DbContext(typeof(ProjectExecutionPortalContext))]
    [Migration("20221101112214_AddOnboardedAppsTable")]
    partial class AddOnboardedAppsTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Equinor.ProjectExecutionPortal.Domain.Entities.OnboardedApp", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AppKey")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedByAzureOid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModifiedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ModifiedByAzureOid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AppKey")
                        .IsUnique();

                    b.ToTable("OnboardedApps");
                });

            modelBuilder.Entity("Equinor.ProjectExecutionPortal.Domain.Entities.Portal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedByAzureOid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<DateTime?>("ModifiedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ModifiedByAzureOid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Portals");
                });

            modelBuilder.Entity("Equinor.ProjectExecutionPortal.Domain.Entities.WorkSurface", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedByAzureOid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ModifiedByAzureOid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<Guid>("PortalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SubText")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("PortalId");

                    b.ToTable("WorkSurfaces");
                });

            modelBuilder.Entity("Equinor.ProjectExecutionPortal.Domain.Entities.WorkSurfaceAppGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccentColor")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedByAzureOid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ExternalId")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("ModifiedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ModifiedByAzureOid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("WorkSurfaceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("WorkSurfaceId");

                    b.ToTable("WorkSurfaceAppGroups");
                });

            modelBuilder.Entity("Equinor.ProjectExecutionPortal.Domain.Entities.WorkSurfaceApplication", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AppGroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AppKey")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedByAzureOid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ExternalId")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsHidden")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ModifiedByAzureOid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("WorkSurfaceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AppGroupId");

                    b.HasIndex("WorkSurfaceId");

                    b.ToTable("WorkSurfaceApplications");
                });

            modelBuilder.Entity("Equinor.ProjectExecutionPortal.Domain.Entities.WorkSurface", b =>
                {
                    b.HasOne("Equinor.ProjectExecutionPortal.Domain.Entities.Portal", "Portal")
                        .WithMany("WorkSurfaces")
                        .HasForeignKey("PortalId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Portal");
                });

            modelBuilder.Entity("Equinor.ProjectExecutionPortal.Domain.Entities.WorkSurfaceAppGroup", b =>
                {
                    b.HasOne("Equinor.ProjectExecutionPortal.Domain.Entities.WorkSurface", "WorkSurface")
                        .WithMany("AppGroups")
                        .HasForeignKey("WorkSurfaceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("WorkSurface");
                });

            modelBuilder.Entity("Equinor.ProjectExecutionPortal.Domain.Entities.WorkSurfaceApplication", b =>
                {
                    b.HasOne("Equinor.ProjectExecutionPortal.Domain.Entities.WorkSurfaceAppGroup", "AppGroup")
                        .WithMany("Applications")
                        .HasForeignKey("AppGroupId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Equinor.ProjectExecutionPortal.Domain.Entities.WorkSurface", "WorkSurface")
                        .WithMany("Applications")
                        .HasForeignKey("WorkSurfaceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AppGroup");

                    b.Navigation("WorkSurface");
                });

            modelBuilder.Entity("Equinor.ProjectExecutionPortal.Domain.Entities.Portal", b =>
                {
                    b.Navigation("WorkSurfaces");
                });

            modelBuilder.Entity("Equinor.ProjectExecutionPortal.Domain.Entities.WorkSurface", b =>
                {
                    b.Navigation("AppGroups");

                    b.Navigation("Applications");
                });

            modelBuilder.Entity("Equinor.ProjectExecutionPortal.Domain.Entities.WorkSurfaceAppGroup", b =>
                {
                    b.Navigation("Applications");
                });
#pragma warning restore 612, 618
        }
    }
}
