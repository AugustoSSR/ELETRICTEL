﻿// <auto-generated />
using System;
using ELETRICTEL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ELETRICTEL.Migrations
{
    [DbContext(typeof(ELETRICTELContext))]
    [Migration("20221005004221_dbCreate")]
    partial class dbCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ELETRICTEL.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Fantasia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Razao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetCep")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetState")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("ELETRICTEL.Models.Engineers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CREA")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RG")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Engineers");
                });

            modelBuilder.Entity("ELETRICTEL.Models.Files", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Book")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Box")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProjectsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("ProjectsId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("ELETRICTEL.Models.ProjectDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ApplicationId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ApprovedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EngineersId")
                        .HasColumnType("int");

                    b.Property<string>("ProjectART")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectKM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectPostes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectStreetART")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProjectsId")
                        .HasColumnType("int");

                    b.Property<string>("Protocol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ProtocolTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("RCommercialId")
                        .HasColumnType("int");

                    b.Property<int>("RResponsibleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EngineersId");

                    b.HasIndex("ProjectsId");

                    b.HasIndex("RCommercialId");

                    b.HasIndex("RResponsibleId");

                    b.ToTable("ProjectDetails");
                });

            modelBuilder.Entity("ELETRICTEL.Models.Projects", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectDetailsId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("TypesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("StatusId");

                    b.HasIndex("TypesId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("ELETRICTEL.Models.RCommercial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RCommercial");
                });

            modelBuilder.Entity("ELETRICTEL.Models.Roles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ELETRICTEL.Models.RResponsible", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("RResponsible");
                });

            modelBuilder.Entity("ELETRICTEL.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("ELETRICTEL.Models.Types", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("ELETRICTEL.Models.UserClients", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Actived")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ChangeTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("cLogin")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("cMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cPassword")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("cPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("UsersC");
                });

            modelBuilder.Entity("ELETRICTEL.Models.UsersViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Actived")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ChangeTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RolesId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("UsersLogin")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("UsersMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsersName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsersPassword")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UsersPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RolesId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ELETRICTEL.Models.Files", b =>
                {
                    b.HasOne("ELETRICTEL.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("ELETRICTEL.Models.Projects", "Projects")
                        .WithMany()
                        .HasForeignKey("ProjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("ELETRICTEL.Models.ProjectDetails", b =>
                {
                    b.HasOne("ELETRICTEL.Models.Engineers", "Engineers")
                        .WithMany("ProjectDetails")
                        .HasForeignKey("EngineersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ELETRICTEL.Models.Projects", "Projects")
                        .WithMany("ProjectDetails")
                        .HasForeignKey("ProjectsId");

                    b.HasOne("ELETRICTEL.Models.RCommercial", "RCommercial")
                        .WithMany("ProjectDetails")
                        .HasForeignKey("RCommercialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ELETRICTEL.Models.RResponsible", "RResponsible")
                        .WithMany("ProjectDetails")
                        .HasForeignKey("RResponsibleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Engineers");

                    b.Navigation("Projects");

                    b.Navigation("RCommercial");

                    b.Navigation("RResponsible");
                });

            modelBuilder.Entity("ELETRICTEL.Models.Projects", b =>
                {
                    b.HasOne("ELETRICTEL.Models.Company", "Company")
                        .WithMany("Projects")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ELETRICTEL.Models.Status", "Status")
                        .WithMany("Projects")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ELETRICTEL.Models.Types", "Types")
                        .WithMany("Projects")
                        .HasForeignKey("TypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Status");

                    b.Navigation("Types");
                });

            modelBuilder.Entity("ELETRICTEL.Models.UserClients", b =>
                {
                    b.HasOne("ELETRICTEL.Models.Company", "Company")
                        .WithMany("UserClients")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("ELETRICTEL.Models.UsersViewModel", b =>
                {
                    b.HasOne("ELETRICTEL.Models.Roles", "Roles")
                        .WithMany("UserViewModel")
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("ELETRICTEL.Models.Company", b =>
                {
                    b.Navigation("Projects");

                    b.Navigation("UserClients");
                });

            modelBuilder.Entity("ELETRICTEL.Models.Engineers", b =>
                {
                    b.Navigation("ProjectDetails");
                });

            modelBuilder.Entity("ELETRICTEL.Models.Projects", b =>
                {
                    b.Navigation("ProjectDetails");
                });

            modelBuilder.Entity("ELETRICTEL.Models.RCommercial", b =>
                {
                    b.Navigation("ProjectDetails");
                });

            modelBuilder.Entity("ELETRICTEL.Models.Roles", b =>
                {
                    b.Navigation("UserViewModel");
                });

            modelBuilder.Entity("ELETRICTEL.Models.RResponsible", b =>
                {
                    b.Navigation("ProjectDetails");
                });

            modelBuilder.Entity("ELETRICTEL.Models.Status", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("ELETRICTEL.Models.Types", b =>
                {
                    b.Navigation("Projects");
                });
#pragma warning restore 612, 618
        }
    }
}
