using Datos.Eventos;
using Datos.Negocios;
using Datos.Servicios;
using Datos.Usuarios;
using Entidades.Eventos;
using Entidades.Negocios;
using Entidades.Servicios;
using Entidades.Usuarios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos {
    public class Context : DbContext {
        public DbSet<USUARIOS> Usuarios { get; set; }
        public DbSet<NEGOCIOS> Negocio { get; set; }
        public DbSet<NEGOCIOUSUARIO> NegocioUsuario { get; set; }
        public DbSet<EVENTOS> Eventos { get; set; }
        public DbSet<SERVICIOS> Servicios { get; set; }


        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            // Tablas
            modelBuilder.ApplyConfiguration(new ID_USUARIO());              // Usuarios
            modelBuilder.ApplyConfiguration(new ID_NEGOCIO());              // Negocios
            modelBuilder.ApplyConfiguration(new ID_EVENTO());               // Eventos
            modelBuilder.ApplyConfiguration(new ID_NEGOCIO_USUARIO());      // Negocios de un usuario
            modelBuilder.ApplyConfiguration(new ID_SERVICIO());             // Servicios de un evento



            base.OnModelCreating(modelBuilder);
        }

    }
}
