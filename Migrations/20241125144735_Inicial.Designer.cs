﻿// <auto-generated />
using System;
using FreimyHidalgo_AP1_P2.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FreimyHidalgo_AP1_P2.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20241125144735_Inicial")]
    partial class Inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FreimyHidalgo_AP1_P2.Models.Combo1", b =>
                {
                    b.Property<int>("ComboId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComboId"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Vendido")
                        .HasColumnType("bit");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("precio")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ComboId");

                    b.ToTable("Combo1");
                });

            modelBuilder.Entity("FreimyHidalgo_AP1_P2.Models.CombosDetalle", b =>
                {
                    b.Property<int>("DetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetalleId"));

                    b.Property<int>("ArticuloId")
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("ComboId")
                        .HasColumnType("int");

                    b.Property<decimal>("costo")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("DetalleId");

                    b.HasIndex("ArticuloId");

                    b.HasIndex("ComboId");

                    b.ToTable("CombosDetalles");
                });

            modelBuilder.Entity("FreimyHidalgo_AP1_P2.Models.Producto", b =>
                {
                    b.Property<int>("ArticuloId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArticuloId"));

                    b.Property<decimal>("Costo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("existencia")
                        .HasColumnType("int");

                    b.HasKey("ArticuloId");

                    b.ToTable("Producto");

                    b.HasData(
                        new
                        {
                            ArticuloId = 1,
                            Costo = 3400m,
                            Descripcion = "Memoria RAM ",
                            Precio = 1200m,
                            existencia = 55
                        },
                        new
                        {
                            ArticuloId = 2,
                            Costo = 5000m,
                            Descripcion = "Monitor ",
                            Precio = 2000m,
                            existencia = 28
                        },
                        new
                        {
                            ArticuloId = 3,
                            Costo = 4300m,
                            Descripcion = "CPU ",
                            Precio = 1250m,
                            existencia = 40
                        });
                });

            modelBuilder.Entity("FreimyHidalgo_AP1_P2.Models.CombosDetalle", b =>
                {
                    b.HasOne("FreimyHidalgo_AP1_P2.Models.Producto", "Articulos")
                        .WithMany()
                        .HasForeignKey("ArticuloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FreimyHidalgo_AP1_P2.Models.Combo1", "Combos")
                        .WithMany("ComboDetalle")
                        .HasForeignKey("ComboId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Articulos");

                    b.Navigation("Combos");
                });

            modelBuilder.Entity("FreimyHidalgo_AP1_P2.Models.Combo1", b =>
                {
                    b.Navigation("ComboDetalle");
                });
#pragma warning restore 612, 618
        }
    }
}