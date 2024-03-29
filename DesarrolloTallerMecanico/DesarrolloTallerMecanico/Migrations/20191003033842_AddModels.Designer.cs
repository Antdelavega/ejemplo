﻿// <auto-generated />
using System;
using DesarrolloTallerMecanico.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DesarrolloTallerMecanico.Migrations
{
    [DbContext(typeof(DesarrolloTallerMecanicoContext))]
    [Migration("20191003033842_AddModels")]
    partial class AddModels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DesarrolloTallerMecanico.Models.Data.DDL.Clientes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("NIT")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("DesarrolloTallerMecanico.Models.Data.DDL.Mecanico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellidos")
                        .IsRequired();

                    b.Property<string>("DPI")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<DateTime>("FechaContratacion");

                    b.Property<string>("Nombres")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Mecanico");
                });

            modelBuilder.Entity("DesarrolloTallerMecanico.Models.Data.DDL.ServicioMecanico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescripcionServicio")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("FechaEntregaVehiculo");

                    b.Property<DateTime>("FechaIngresoVehiculo");

                    b.Property<int>("TipoServicioId");

                    b.Property<int>("VehiculoId");

                    b.HasKey("Id");

                    b.HasIndex("TipoServicioId");

                    b.HasIndex("VehiculoId");

                    b.ToTable("ServicioMecanico");
                });

            modelBuilder.Entity("DesarrolloTallerMecanico.Models.Data.DDL.TipoServicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(75);

                    b.HasKey("Id");

                    b.ToTable("TipoServicio");
                });

            modelBuilder.Entity("DesarrolloTallerMecanico.Models.Data.DDL.TipoVehiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.ToTable("TipoVehiculo");
                });

            modelBuilder.Entity("DesarrolloTallerMecanico.Models.Data.DDL.Vehiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId");

                    b.Property<string>("Descripcion");

                    b.Property<string>("NumeroChasis");

                    b.Property<string>("NumeroMotor");

                    b.Property<string>("NumeroPlaca");

                    b.Property<int>("TipoVehiculoId");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("TipoVehiculoId");

                    b.ToTable("Vehiculo");
                });

            modelBuilder.Entity("DesarrolloTallerMecanico.Models.Data.DDL.ServicioMecanico", b =>
                {
                    b.HasOne("DesarrolloTallerMecanico.Models.Data.DDL.TipoServicio", "TipoServicio")
                        .WithMany("ServicioMecanicos")
                        .HasForeignKey("TipoServicioId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DesarrolloTallerMecanico.Models.Data.DDL.Vehiculo", "Vehiculo")
                        .WithMany()
                        .HasForeignKey("VehiculoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DesarrolloTallerMecanico.Models.Data.DDL.Vehiculo", b =>
                {
                    b.HasOne("DesarrolloTallerMecanico.Models.Data.DDL.Clientes", "Cliente")
                        .WithMany("Vehiculos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DesarrolloTallerMecanico.Models.Data.DDL.TipoVehiculo", "TipoVehiculo")
                        .WithMany("Vehiculos")
                        .HasForeignKey("TipoVehiculoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
