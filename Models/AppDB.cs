using Identidad.Models.Recursos;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identidad.Models;
using Identidad.ViewModels;


namespace Identidad.Models
{
    public class AppDB:IdentityDbContext<Usuario>
    {
        public AppDB(Microsoft.EntityFrameworkCore.DbContextOptions<AppDB> options)
            : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Seed();

            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
            modelBuilder.Entity<Etapa>()
                .HasIndex(b => b.NombreEtapa)
                .IsUnique()
                .HasName("IXNombre");

            modelBuilder.Entity<Pareja>()
               .HasIndex(b => new { b.Jugador1, b.Jugador2 } ).IsUnique()
               .IsUnique()
               .HasName("IXPareja");

            modelBuilder.Entity<Anotacion>()
               .HasIndex(b => new { b.TorneoRefId, b.PerfilRefId }).IsUnique()
               .IsUnique()
               .HasName("IXPerTor");
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<Calle> Calles { get; set; }
        public DbSet<TipoDocumento> TipoDocumentos { get; set; }
        public DbSet<Federacion> Federaciones { get; set; }
        public DbSet<Club> Club { get; set; }
        public DbSet<Perfil> Perfiles { get; set; }
        public DbSet<Juego> Juegoes { get; set; }
        public DbSet<Categoria> Categorias{ get; set; }
        public DbSet<CategoriaTorneo> CategoriasTorneos { get; set; }
        public DbSet<SistemaTorneo> SistemasTorneos { get; set; }
        public DbSet<CantidadJugadores> CantidadJugadores { get; set; }
        public DbSet<CategoriaJugador> CategoriasJugadores { get; set; }
        public DbSet<Inscripcion> Inscripciones { get; set; }
        public DbSet<Torneo> Torneos { get; set; }
        public DbSet<Torneo2> Torneos2 { get; set; }
        public DbSet<Pareja> Parejas { get; set; }
        public DbSet<Zona> Zonas { get; set; }
        public DbSet<ZonaJugador> ZonasJugadores { get; set; }
        public DbSet<Anotacion> Anotaciones { get; set; }
        public DbSet<Etapa> Etapas { get; set; }
        public DbSet<Zone> Zones { get; set; }
        public DbSet<Partido> Partidos { get; set; }
        public DbSet<Galeria> Galerias { get; set; }
        public DbSet<GaleriaTorneos> GaleriasTorneos { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<Clasificado> Clasificados { get; set; }
        public DbSet<Eliminado> Eliminados { get; set; }

        public DbSet<Ranking> Rankings { get; set; }
        public DbSet<Ranking2> Rankings2 { get; set; }
        public DbSet<Ordenamiento> Ordenamientos { get; set; }
        public DbSet<PresidenteFederacion> PresidentesFederacion { get; set; }

        public DbSet<ApoderadoFederacion> ApoderadosFederacion { get; set; }
        public DbSet<PresidenteClub> PresidentesClub { get; set; }
        public DbSet<ApoderadoClub> ApoderadosClub { get; set; }

    }
}
