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
    [Migration("20231003104207_RemoveTitleFromOnboardedContext")]
    partial class RemoveTitleFromOnboardedContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Equinor.ProjectExecutionPortal.Domain.Entities.AppGroup", b =>
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

                    b.HasKey("Id");

                    b.ToTable("AppGroups");
                });

            modelBuilder.Entity("Equinor.ProjectExecutionPortal.Domain.Entities.OnboardedApp", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AppGroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AppKey")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedByAzureOid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsLegacy")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ModifiedByAzureOid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppGroupId");

                    b.HasIndex("AppKey")
                        .IsUnique();

                    b.ToTable("OnboardedApps");
                });

            modelBuilder.Entity("Equinor.ProjectExecutionPortal.Domain.Entities.OnboardedContext", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedByAzureOid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<string>("ExternalId")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("ModifiedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ModifiedByAzureOid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.ToTable("OnboardedContexts");
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

                    b.Property<string>("Description")
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<string>("Key")
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

                    b.HasIndex("Key")
                        .IsUnique();

                    b.HasIndex("PortalId");

                    b.ToTable("WorkSurfaces");
                });

            modelBuilder.Entity("Equinor.ProjectExecutionPortal.Domain.Entities.WorkSurfaceApp", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedByAzureOid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsHidden")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ModifiedByAzureOid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OnboardedAppId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("OnboardedContextId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WorkSurfaceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OnboardedAppId");

                    b.HasIndex("OnboardedContextId");

                    b.HasIndex("WorkSurfaceId");

                    b.ToTable("WorkSurfaceApps");
                });

            modelBuilder.Entity("Equinor.ProjectExecutionPortal.Domain.Entities.OnboardedApp", b =>
                {
                    b.HasOne("Equinor.ProjectExecutionPortal.Domain.Entities.AppGroup", "AppGroup")
                        .WithMany("Apps")
                        .HasForeignKey("AppGroupId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AppGroup");
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

            modelBuilder.Entity("Equinor.ProjectExecutionPortal.Domain.Entities.WorkSurfaceApp", b =>
                {
                    b.HasOne("Equinor.ProjectExecutionPortal.Domain.Entities.OnboardedApp", "OnboardedApp")
                        .WithMany()
                        .HasForeignKey("OnboardedAppId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Equinor.ProjectExecutionPortal.Domain.Entities.OnboardedContext", "OnboardedContext")
                        .WithMany("Apps")
                        .HasForeignKey("OnboardedContextId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Equinor.ProjectExecutionPortal.Domain.Entities.WorkSurface", "WorkSurface")
                        .WithMany("Apps")
                        .HasForeignKey("WorkSurfaceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("OnboardedApp");

                    b.Navigation("OnboardedContext");

                    b.Navigation("WorkSurface");
                });

            modelBuilder.Entity("Equinor.ProjectExecutionPortal.Domain.Entities.AppGroup", b =>
                {
                    b.Navigation("Apps");
                });

            modelBuilder.Entity("Equinor.ProjectExecutionPortal.Domain.Entities.OnboardedContext", b =>
                {
                    b.Navigation("Apps");
                });

            modelBuilder.Entity("Equinor.ProjectExecutionPortal.Domain.Entities.Portal", b =>
                {
                    b.Navigation("WorkSurfaces");
                });

            modelBuilder.Entity("Equinor.ProjectExecutionPortal.Domain.Entities.WorkSurface", b =>
                {
                    b.Navigation("Apps");
                });
#pragma warning restore 612, 618
        }
    }
}
