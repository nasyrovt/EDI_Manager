﻿// <auto-generated />
using System;
using EDI_Manager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EDI_Manager.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("ClientAdress")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("ClientAge")
                        .HasColumnType("int");

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("ClientSurName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("ProfileCreationDate")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("ClientId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("EDI_Manager.Developer", b =>
                {
                    b.Property<int>("DeveloperId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeveloperId"), 1L, 1);

                    b.Property<string>("DeveloperAdress")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("DeveloperAge")
                        .HasColumnType("int");

                    b.Property<string>("DeveloperName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("DeveloperSurName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("HireDate")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("DeveloperId");

                    b.ToTable("Developers");
                });

            modelBuilder.Entity("EDI_Manager.Feed", b =>
                {
                    b.Property<int>("FeedId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FeedId"), 1L, 1);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("DeveloperId")
                        .HasColumnType("int");

                    b.Property<int?>("FTPAccountId")
                        .HasColumnType("int");

                    b.Property<string>("FeedName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("SourceFileId")
                        .HasColumnType("int");

                    b.Property<string>("TargetEmails")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("TargetFileTypeId")
                        .HasColumnType("int");

                    b.HasKey("FeedId");

                    b.HasIndex("ClientId");

                    b.HasIndex("DeveloperId");

                    b.HasIndex("FTPAccountId");

                    b.HasIndex("SourceFileId");

                    b.HasIndex("TargetFileTypeId");

                    b.ToTable("Feeds");
                });

            modelBuilder.Entity("EDI_Manager.File", b =>
                {
                    b.Property<int>("FileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FileId"), 1L, 1);

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("FileTypeId")
                        .HasColumnType("int");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.HasKey("FileId");

                    b.HasIndex("FileTypeId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("EDI_Manager.FileType", b =>
                {
                    b.Property<int>("FileTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FileTypeId"), 1L, 1);

                    b.Property<string>("FileTypeName")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("FileTypeId");

                    b.ToTable("FileTypes");
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

            modelBuilder.Entity("EDI_Manager.Feed", b =>
                {
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
                        .HasForeignKey("FTPAccountId");

                    b.HasOne("EDI_Manager.File", "SourceFile")
                        .WithMany()
                        .HasForeignKey("SourceFileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EDI_Manager.FileType", "TargetFileType")
                        .WithMany()
                        .HasForeignKey("TargetFileTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Developer");

                    b.Navigation("FTPAccount");

                    b.Navigation("SourceFile");

                    b.Navigation("TargetFileType");
                });

            modelBuilder.Entity("EDI_Manager.File", b =>
                {
                    b.HasOne("EDI_Manager.FileType", "FileType")
                        .WithMany()
                        .HasForeignKey("FileTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FileType");
                });
#pragma warning restore 612, 618
        }
    }
}
