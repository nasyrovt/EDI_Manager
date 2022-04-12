﻿// <auto-generated />
using System;
using EDI_Manager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EDI_Manager.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220409001131_GroupSubGroupPolicyNumberDelete")]
    partial class GroupSubGroupPolicyNumberDelete
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EDI_Manager.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientId"), 1L, 1);

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ClientTaxId")
                        .HasColumnType("int");

                    b.Property<string>("ContactMails")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ContactPhoneNumbers")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ClientId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("EDI_Manager.Developer", b =>
                {
                    b.Property<int>("DeveloperId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeveloperId"), 1L, 1);

                    b.Property<string>("DeveloperFirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("DeveloperLastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("DeveloperMail")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("DeveloperRole")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("DeveloperId");

                    b.ToTable("Developers");
                });

            modelBuilder.Entity("EDI_Manager.Feed", b =>
                {
                    b.Property<int>("FeedId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FeedId"), 1L, 1);

                    b.Property<int?>("BusinessDayOfMonth")
                        .HasColumnType("int");

                    b.Property<int>("CarrierId")
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("DeveloperId")
                        .HasColumnType("int");

                    b.Property<string>("EndDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FTPAccountId")
                        .HasColumnType("int");

                    b.Property<int>("FeedFrequencyId")
                        .HasColumnType("int");

                    b.Property<string>("FeedName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("FeedSecurityTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("FrequencyTimes")
                        .HasColumnType("int");

                    b.Property<int>("InProduction")
                        .HasColumnType("int");

                    b.Property<int>("IsChangesOnly")
                        .HasColumnType("int");

                    b.Property<string>("PGPPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Series")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SourceFileId")
                        .HasColumnType("int");

                    b.Property<string>("StartDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TargetFileMimeId")
                        .HasColumnType("int");

                    b.Property<int?>("TargetFileTypeFileMimeId")
                        .HasColumnType("int");

                    b.Property<int?>("WeeklyRecurDay")
                        .HasColumnType("int");

                    b.Property<string>("ZipPassword")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FeedId");

                    b.HasIndex("CarrierId");

                    b.HasIndex("ClientId");

                    b.HasIndex("DeveloperId");

                    b.HasIndex("FTPAccountId");

                    b.HasIndex("FeedFrequencyId");

                    b.HasIndex("FeedSecurityTypeId");

                    b.HasIndex("SourceFileId");

                    b.HasIndex("TargetFileTypeFileMimeId");

                    b.ToTable("Feeds");
                });

            modelBuilder.Entity("EDI_Manager.File", b =>
                {
                    b.Property<int>("FileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FileId"), 1L, 1);

                    b.Property<int>("FileMimeId")
                        .HasColumnType("int");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.HasKey("FileId");

                    b.HasIndex("FileMimeId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("EDI_Manager.FileMime", b =>
                {
                    b.Property<int>("FileMimeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FileMimeId"), 1L, 1);

                    b.Property<string>("FileMimeName")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("FileMimeId");

                    b.ToTable("FileMimes");
                });

            modelBuilder.Entity("EDI_Manager.SSHKey", b =>
                {
                    b.Property<int>("SSHKeyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SSHKeyId"), 1L, 1);

                    b.Property<string>("FTPHost")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SSHKeyId");

                    b.ToTable("SSHKeys");
                });

            modelBuilder.Entity("EDI_Manager.TableDefinitions.Carrier", b =>
                {
                    b.Property<int>("CarrierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarrierId"), 1L, 1);

                    b.Property<string>("Adress1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Adress2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarrierName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CarrierTaxId")
                        .HasColumnType("int");

                    b.Property<int>("CarrierTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Phones")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebSite")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CarrierId");

                    b.HasIndex("CarrierTypeId");

                    b.ToTable("Carriers");
                });

            modelBuilder.Entity("EDI_Manager.TableDefinitions.CarrierType", b =>
                {
                    b.Property<int>("CarrierTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarrierTypeId"), 1L, 1);

                    b.Property<string>("CarrierTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CarrierTypeId");

                    b.ToTable("CarrierTypes");
                });

            modelBuilder.Entity("EDI_Manager.TableDefinitions.FeedFrequency", b =>
                {
                    b.Property<int>("FeedFrequencyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FeedFrequencyId"), 1L, 1);

                    b.Property<string>("FeedFrequencyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FeedFrequencyId");

                    b.ToTable("FeedFrequency");
                });

            modelBuilder.Entity("EDI_Manager.TableDefinitions.FeedSecurityType", b =>
                {
                    b.Property<int>("FeedSecurityTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FeedSecurityTypeId"), 1L, 1);

                    b.Property<string>("FeedSecurityTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FeedSecurityTypeId");

                    b.ToTable("FeedSecurityType");
                });

            modelBuilder.Entity("EDI_Manager.TableDefinitions.FTPAccount", b =>
                {
                    b.Property<int>("FTPAccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FTPAccountId"), 1L, 1);

                    b.Property<string>("FTPDirectory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FTPHost")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FTPPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FTPPort")
                        .HasColumnType("int");

                    b.Property<string>("FTPType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FTPUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FTPAccountId");

                    b.ToTable("FTPAccounts");
                });

            modelBuilder.Entity("EDI_Manager.TableDefinitions.Platform", b =>
                {
                    b.Property<int>("PlatformId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlatformId"), 1L, 1);

                    b.Property<string>("PlatformName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlatformId");

                    b.ToTable("Platforms");
                });

            modelBuilder.Entity("EDI_Manager.Feed", b =>
                {
                    b.HasOne("EDI_Manager.TableDefinitions.Carrier", "Carrier")
                        .WithMany()
                        .HasForeignKey("CarrierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EDI_Manager.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EDI_Manager.Developer", "Developer")
                        .WithMany()
                        .HasForeignKey("DeveloperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EDI_Manager.TableDefinitions.FTPAccount", "FTPAccount")
                        .WithMany()
                        .HasForeignKey("FTPAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EDI_Manager.TableDefinitions.FeedFrequency", "FeedFrequency")
                        .WithMany()
                        .HasForeignKey("FeedFrequencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EDI_Manager.TableDefinitions.FeedSecurityType", "FeedSecurityType")
                        .WithMany()
                        .HasForeignKey("FeedSecurityTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EDI_Manager.File", "SourceFile")
                        .WithMany()
                        .HasForeignKey("SourceFileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EDI_Manager.FileMime", "TargetFileType")
                        .WithMany()
                        .HasForeignKey("TargetFileTypeFileMimeId");

                    b.Navigation("Carrier");

                    b.Navigation("Client");

                    b.Navigation("Developer");

                    b.Navigation("FTPAccount");

                    b.Navigation("FeedFrequency");

                    b.Navigation("FeedSecurityType");

                    b.Navigation("SourceFile");

                    b.Navigation("TargetFileType");
                });

            modelBuilder.Entity("EDI_Manager.File", b =>
                {
                    b.HasOne("EDI_Manager.FileMime", "FileMime")
                        .WithMany()
                        .HasForeignKey("FileMimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FileMime");
                });

            modelBuilder.Entity("EDI_Manager.TableDefinitions.Carrier", b =>
                {
                    b.HasOne("EDI_Manager.TableDefinitions.CarrierType", "CarrierType")
                        .WithMany()
                        .HasForeignKey("CarrierTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarrierType");
                });
#pragma warning restore 612, 618
        }
    }
}
