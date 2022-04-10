﻿// <auto-generated />
using System;
using Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Web.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220320153313_InitNegocio")]
    partial class InitNegocio
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entidades.Usuarios.USUARIOS", b =>
                {
                    b.Property<long>("ID_USUARIO")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("APELLIDOS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EMAIL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FECHA_NACIMIENTO")
                        .HasColumnType("datetime2");

                    b.Property<string>("NOMBRE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PASSWORD")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TELEFONO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("USUARIO")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_USUARIO");

                    b.ToTable("USUARIOS");
                });
#pragma warning restore 612, 618
        }
    }
}
