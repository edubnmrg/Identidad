﻿// <auto-generated />
using System;
using Identidad.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Identidad.Migrations
{
    [DbContext(typeof(AppDB))]
    [Migration("20200207232857_Anotacion1")]
    partial class Anotacion1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Identidad.Models.Anotacion", b =>
                {
                    b.Property<int>("AnotacionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PerfilFK")
                        .HasColumnType("int");

                    b.Property<int>("TorneoFK")
                        .HasColumnType("int");

                    b.HasKey("AnotacionID");

                    b.HasIndex("PerfilFK");

                    b.HasIndex("TorneoFK");

                    b.ToTable("Anotaciones");
                });

            modelBuilder.Entity("Identidad.Models.Calle", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.HasKey("ID");

                    b.ToTable("Calles");
                });

            modelBuilder.Entity("Identidad.Models.CategoriaJugador", b =>
                {
                    b.Property<int>("CategoriaJugadorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoriaFK")
                        .HasColumnType("int");

                    b.Property<int>("JuegoFK")
                        .HasColumnType("int");

                    b.Property<int>("PerfilFK")
                        .HasColumnType("int");

                    b.HasKey("CategoriaJugadorID");

                    b.HasIndex("CategoriaFK");

                    b.HasIndex("JuegoFK");

                    b.HasIndex("PerfilFK");

                    b.ToTable("CategoriasJugadores");
                });

            modelBuilder.Entity("Identidad.Models.Club", b =>
                {
                    b.Property<int>("ClubID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Altura")
                        .IsRequired()
                        .HasColumnType("nvarchar(16)")
                        .HasMaxLength(16);

                    b.Property<string>("Calle")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<string>("ClubEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("ClubUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<int>("FedID")
                        .HasColumnType("int");

                    b.Property<string>("NombreClub")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<int>("ProvinciaID")
                        .HasColumnType("int");

                    b.Property<string>("SiglaClub")
                        .IsRequired()
                        .HasColumnType("nvarchar(16)")
                        .HasMaxLength(16);

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(16)")
                        .HasMaxLength(16);

                    b.HasKey("ClubID");

                    b.HasIndex("FedID");

                    b.HasIndex("ProvinciaID");

                    b.ToTable("Club");
                });

            modelBuilder.Entity("Identidad.Models.Federacion", b =>
                {
                    b.Property<int>("FedID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FedUrl")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<int>("altura")
                        .HasColumnType("int");

                    b.Property<string>("calle")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<string>("ciudad")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<string>("fedEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<int>("provinciaID")
                        .HasColumnType("int");

                    b.Property<string>("sigla")
                        .IsRequired()
                        .HasColumnType("nvarchar(16)")
                        .HasMaxLength(16);

                    b.Property<string>("telefono")
                        .HasColumnType("nvarchar(16)")
                        .HasMaxLength(16);

                    b.HasKey("FedID");

                    b.HasIndex("provinciaID");

                    b.ToTable("Federaciones");
                });

            modelBuilder.Entity("Identidad.Models.Inscripcion", b =>
                {
                    b.Property<int>("InscripcionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PerfilFK")
                        .HasColumnType("int");

                    b.Property<int>("TorneoFK")
                        .HasColumnType("int");

                    b.Property<int?>("TorneoID")
                        .HasColumnType("int");

                    b.HasKey("InscripcionID");

                    b.HasIndex("PerfilFK");

                    b.HasIndex("TorneoFK");

                    b.HasIndex("TorneoID");

                    b.ToTable("Inscripciones");
                });

            modelBuilder.Entity("Identidad.Models.Pareja", b =>
                {
                    b.Property<int>("ParejaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Jugador1")
                        .HasColumnType("int");

                    b.Property<int>("Jugador2")
                        .HasColumnType("int");

                    b.Property<int?>("Perfil1ID")
                        .HasColumnType("int");

                    b.Property<int?>("Perfil2ID")
                        .HasColumnType("int");

                    b.HasKey("ParejaID");

                    b.HasIndex("Perfil1ID");

                    b.HasIndex("Perfil2ID");

                    b.ToTable("Parejas");
                });

            modelBuilder.Entity("Identidad.Models.Perfil", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(512)")
                        .HasMaxLength(512);

                    b.Property<int>("altura")
                        .HasColumnType("int");

                    b.Property<string>("apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("calle")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<string>("celular")
                        .HasColumnType("nvarchar(16)")
                        .HasMaxLength(16);

                    b.Property<string>("ciudad")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<int>("clubID")
                        .HasColumnType("int");

                    b.Property<byte[]>("foto")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("fotoPath")
                        .HasColumnType("nvarchar(512)")
                        .HasMaxLength(512);

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<int>("numeroDocumento")
                        .HasColumnType("int");

                    b.Property<int>("provinciaID")
                        .HasColumnType("int");

                    b.Property<int>("tDocID")
                        .HasColumnType("int");

                    b.Property<string>("telefono")
                        .HasColumnType("nvarchar(16)")
                        .HasMaxLength(16);

                    b.Property<int?>("tipoDeDocumentoID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("clubID");

                    b.HasIndex("provinciaID");

                    b.HasIndex("tipoDeDocumentoID");

                    b.ToTable("Perfiles");
                });

            modelBuilder.Entity("Identidad.Models.Recursos.CantidadJugadores", b =>
                {
                    b.Property<int>("cantJugID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("cantJug")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("cantJugID");

                    b.ToTable("CantidadJugadores");
                });

            modelBuilder.Entity("Identidad.Models.Recursos.Categoria", b =>
                {
                    b.Property<int>("categoriaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(8)")
                        .HasMaxLength(8);

                    b.Property<string>("categoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(32)")
                        .HasMaxLength(32);

                    b.HasKey("categoriaID");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("Identidad.Models.Recursos.CategoriaTorneo", b =>
                {
                    b.Property<int>("catTorneoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(8)")
                        .HasMaxLength(8);

                    b.Property<string>("catTorneo")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.HasKey("catTorneoID");

                    b.ToTable("CategoriasTorneos");
                });

            modelBuilder.Entity("Identidad.Models.Recursos.Ciudad", b =>
                {
                    b.Property<int>("CiudadID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProvinciaID")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.HasKey("CiudadID");

                    b.HasIndex("ProvinciaID");

                    b.ToTable("Ciudades");
                });

            modelBuilder.Entity("Identidad.Models.Recursos.Juego", b =>
                {
                    b.Property<int>("JuegoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nombreJuego")
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.HasKey("JuegoID");

                    b.ToTable("Juegoes");
                });

            modelBuilder.Entity("Identidad.Models.Recursos.Provincia", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.HasKey("ID");

                    b.ToTable("Provincias");
                });

            modelBuilder.Entity("Identidad.Models.Recursos.SistemaTorneo", b =>
                {
                    b.Property<int>("sisTorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("sisTor")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.HasKey("sisTorID");

                    b.ToTable("SistemasTorneos");
                });

            modelBuilder.Entity("Identidad.Models.Recursos.TipoDocumento", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abreviacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(3)")
                        .HasMaxLength(3);

                    b.Property<string>("tipoDeDocumento")
                        .IsRequired()
                        .HasColumnType("nvarchar(32)")
                        .HasMaxLength(32);

                    b.HasKey("ID");

                    b.ToTable("TipoDocumentos");
                });

            modelBuilder.Entity("Identidad.Models.Torneo", b =>
                {
                    b.Property<int>("TorneoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CanJugFK")
                        .HasColumnType("int");

                    b.Property<int?>("CanJugcantJugID")
                        .HasColumnType("int");

                    b.Property<int>("CatFK")
                        .HasColumnType("int");

                    b.Property<int>("CatTorFK")
                        .HasColumnType("int");

                    b.Property<int>("ClubFK")
                        .HasColumnType("int");

                    b.Property<DateTime>("Desde")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Hasta")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreTorneo")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Notas")
                        .HasColumnType("nvarchar(512)")
                        .HasMaxLength(512);

                    b.Property<int>("SisTorFK")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorInscripcion")
                        .HasColumnType("decimal(16 ,0)");

                    b.Property<int?>("catTorneoID")
                        .HasColumnType("int");

                    b.Property<int?>("categoriaID")
                        .HasColumnType("int");

                    b.Property<int?>("sisTorID")
                        .HasColumnType("int");

                    b.HasKey("TorneoID");

                    b.HasIndex("CanJugcantJugID");

                    b.HasIndex("ClubFK");

                    b.HasIndex("catTorneoID");

                    b.HasIndex("categoriaID");

                    b.HasIndex("sisTorID");

                    b.ToTable("Torneos");
                });

            modelBuilder.Entity("Identidad.Models.Usuario", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Identidad.Models.Zona", b =>
                {
                    b.Property<int>("ZonaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CantidadJugadores")
                        .HasColumnType("int");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<int>("TorneoID")
                        .HasColumnType("int");

                    b.HasKey("ZonaID");

                    b.HasIndex("TorneoID");

                    b.ToTable("Zonas");
                });

            modelBuilder.Entity("Identidad.Models.ZonaJugador", b =>
                {
                    b.Property<int>("ZonaJugadorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("JugadorID")
                        .HasColumnType("int");

                    b.Property<int>("ZonaID")
                        .HasColumnType("int");

                    b.HasKey("ZonaJugadorID");

                    b.ToTable("ZonasJugadores");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Identidad.Models.Anotacion", b =>
                {
                    b.HasOne("Identidad.Models.Club", "Perfil")
                        .WithMany()
                        .HasForeignKey("PerfilFK")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Identidad.Models.Club", "Torneo")
                        .WithMany()
                        .HasForeignKey("TorneoFK")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Identidad.Models.CategoriaJugador", b =>
                {
                    b.HasOne("Identidad.Models.Recursos.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaFK")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Identidad.Models.Recursos.Juego", "Juego")
                        .WithMany()
                        .HasForeignKey("JuegoFK")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Identidad.Models.Perfil", "Perfil")
                        .WithMany()
                        .HasForeignKey("PerfilFK")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Identidad.Models.Club", b =>
                {
                    b.HasOne("Identidad.Models.Federacion", "Federacion")
                        .WithMany("clubes")
                        .HasForeignKey("FedID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Identidad.Models.Recursos.Provincia", "Provincia")
                        .WithMany()
                        .HasForeignKey("ProvinciaID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Identidad.Models.Federacion", b =>
                {
                    b.HasOne("Identidad.Models.Recursos.Provincia", "Provincia")
                        .WithMany()
                        .HasForeignKey("provinciaID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Identidad.Models.Inscripcion", b =>
                {
                    b.HasOne("Identidad.Models.Club", "Perfil")
                        .WithMany()
                        .HasForeignKey("PerfilFK")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Identidad.Models.Club", "Torneo")
                        .WithMany()
                        .HasForeignKey("TorneoFK")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Identidad.Models.Torneo", null)
                        .WithMany("Inscriptos")
                        .HasForeignKey("TorneoID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Identidad.Models.Pareja", b =>
                {
                    b.HasOne("Identidad.Models.Perfil", "Perfil1")
                        .WithMany()
                        .HasForeignKey("Perfil1ID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Identidad.Models.Perfil", "Perfil2")
                        .WithMany()
                        .HasForeignKey("Perfil2ID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Identidad.Models.Perfil", b =>
                {
                    b.HasOne("Identidad.Models.Club", "club")
                        .WithMany()
                        .HasForeignKey("clubID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Identidad.Models.Recursos.Provincia", "Provincia")
                        .WithMany()
                        .HasForeignKey("provinciaID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Identidad.Models.Recursos.TipoDocumento", "tipoDeDocumento")
                        .WithMany()
                        .HasForeignKey("tipoDeDocumentoID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Identidad.Models.Recursos.Ciudad", b =>
                {
                    b.HasOne("Identidad.Models.Recursos.Provincia", "Provincia")
                        .WithMany("ciudades")
                        .HasForeignKey("ProvinciaID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Identidad.Models.Torneo", b =>
                {
                    b.HasOne("Identidad.Models.Recursos.CantidadJugadores", "CanJug")
                        .WithMany()
                        .HasForeignKey("CanJugcantJugID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Identidad.Models.Club", "Club")
                        .WithMany()
                        .HasForeignKey("ClubFK")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Identidad.Models.Recursos.CategoriaTorneo", "CatTor")
                        .WithMany()
                        .HasForeignKey("catTorneoID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Identidad.Models.Recursos.Categoria", "Cat")
                        .WithMany()
                        .HasForeignKey("categoriaID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Identidad.Models.Recursos.SistemaTorneo", "SisTor")
                        .WithMany()
                        .HasForeignKey("sisTorID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Identidad.Models.Zona", b =>
                {
                    b.HasOne("Identidad.Models.Torneo", "Torneo")
                        .WithMany()
                        .HasForeignKey("TorneoID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Identidad.Models.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Identidad.Models.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Identidad.Models.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Identidad.Models.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
