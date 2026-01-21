using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LuminTrack.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("DefaultConnection") { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Luminaria> Luminarias { get; set; }
        public DbSet<Reporte> Reportes { get; set; }
        public DbSet<OrdenTrabajo> OrdenesTrabajo { get; set; }

    }
}