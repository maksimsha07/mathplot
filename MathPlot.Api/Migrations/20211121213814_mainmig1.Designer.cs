﻿// <auto-generated />
using System;
using MathPlot.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MathPlot.Api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211121213814_mainmig1")]
    partial class mainmig1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("MathPlot.Api.Entity.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("PageId")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("commented")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PageId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("MathPlot.Api.Entity.MappingGauss", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("bifur")
                        .HasColumnType("boolean");

                    b.Property<string>("path")
                        .HasColumnType("text");

                    b.Property<bool>("pokazlapuniva")
                        .HasColumnType("boolean");

                    b.Property<double>("r")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("mappingGausses");
                });

            modelBuilder.Entity("MathPlot.Api.Entity.MappingLogistic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("bifur")
                        .HasColumnType("boolean");

                    b.Property<string>("path")
                        .HasColumnType("text");

                    b.Property<bool>("pokazlapuniva")
                        .HasColumnType("boolean");

                    b.Property<double>("r")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("mappingLogistics");
                });

            modelBuilder.Entity("MathPlot.Api.Entity.MappingPlank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("bifur")
                        .HasColumnType("boolean");

                    b.Property<string>("path")
                        .HasColumnType("text");

                    b.Property<bool>("pokazlapuniva")
                        .HasColumnType("boolean");

                    b.Property<double>("r")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("MappingPlanks");
                });

            modelBuilder.Entity("MathPlot.Api.Entity.MappingSinus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("bifur")
                        .HasColumnType("boolean");

                    b.Property<string>("path")
                        .HasColumnType("text");

                    b.Property<bool>("pokazlapuniva")
                        .HasColumnType("boolean");

                    b.Property<double>("r")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("MappingSinus");
                });

            modelBuilder.Entity("MathPlot.Api.Entity.MappingTwo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("bifur")
                        .HasColumnType("boolean");

                    b.Property<string>("path")
                        .HasColumnType("text");

                    b.Property<bool>("pokazlapuniva")
                        .HasColumnType("boolean");

                    b.Property<double>("r")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("mappingTwos");
                });

            modelBuilder.Entity("MathPlot.Api.Entity.Page", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Pages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            name = "OneDimensionalMappings"
                        },
                        new
                        {
                            Id = 2,
                            name = "BifurcationTheory"
                        },
                        new
                        {
                            Id = 3,
                            name = "LyapunovExponentsTheory"
                        },
                        new
                        {
                            Id = 4,
                            name = "TheoryLogistic"
                        },
                        new
                        {
                            Id = 5,
                            name = "TwoDimensionalMappings"
                        });
                });

            modelBuilder.Entity("MathPlot.Api.Entity.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Genre")
                        .HasColumnType("boolean");

                    b.Property<string>("ImagePath")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Login")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("Phone")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("68b5a52e-ae0e-468a-9228-2e55a9b7ace7"),
                            Email = "deevzmak1234@mail.ru",
                            FirstName = "Максим",
                            Genre = true,
                            LastName = "Чешихин",
                            Login = "Maksim",
                            Password = "qwertyuiop123",
                            Phone = 89094352590L
                        });
                });

            modelBuilder.Entity("MathPlot.Api.Entity.Comment", b =>
                {
                    b.HasOne("MathPlot.Api.Entity.Page", "page")
                        .WithMany("Comments")
                        .HasForeignKey("PageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MathPlot.Api.Entity.User", "user")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("page");

                    b.Navigation("user");
                });

            modelBuilder.Entity("MathPlot.Api.Entity.MappingGauss", b =>
                {
                    b.HasOne("MathPlot.Api.Entity.User", "user")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("MathPlot.Api.Entity.MappingLogistic", b =>
                {
                    b.HasOne("MathPlot.Api.Entity.User", "user")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("MathPlot.Api.Entity.MappingPlank", b =>
                {
                    b.HasOne("MathPlot.Api.Entity.User", "user")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("MathPlot.Api.Entity.MappingSinus", b =>
                {
                    b.HasOne("MathPlot.Api.Entity.User", "user")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("MathPlot.Api.Entity.MappingTwo", b =>
                {
                    b.HasOne("MathPlot.Api.Entity.User", "user")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("MathPlot.Api.Entity.Page", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}