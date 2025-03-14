﻿// <auto-generated />
using System;
using EFC_Progetto_Sett_1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFC_Progetto_Sett_1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250314145909_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EFC_Progetto_Sett_1.Models.Trasgressore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cognome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataRegistrazione")
                        .HasColumnType("datetime2");

                    b.Property<string>("Indirizzo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Trasgressori");
                });

            modelBuilder.Entity("EFC_Progetto_Sett_1.Models.Verbale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataViolazione")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Importo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PuntiDecurtati")
                        .HasColumnType("int");

                    b.Property<int>("TrasgressoreId")
                        .HasColumnType("int");

                    b.Property<int>("ViolazioneId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TrasgressoreId");

                    b.HasIndex("ViolazioneId");

                    b.ToTable("Verbali");
                });

            modelBuilder.Entity("EFC_Progetto_Sett_1.Models.Violazione", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descrizione")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Importo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PuntiDecurtati")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Violazioni");
                });

            modelBuilder.Entity("EFC_Progetto_Sett_1.Models.Verbale", b =>
                {
                    b.HasOne("EFC_Progetto_Sett_1.Models.Trasgressore", "Trasgressore")
                        .WithMany("Verbali")
                        .HasForeignKey("TrasgressoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFC_Progetto_Sett_1.Models.Violazione", "Violazione")
                        .WithMany()
                        .HasForeignKey("ViolazioneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trasgressore");

                    b.Navigation("Violazione");
                });

            modelBuilder.Entity("EFC_Progetto_Sett_1.Models.Trasgressore", b =>
                {
                    b.Navigation("Verbali");
                });
#pragma warning restore 612, 618
        }
    }
}
