using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace fcs.web.Models
{
    public class FcsDbContext : DbContext
    {
        public FcsDbContext() : base("name=FcsEntities")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Articolo> Articoli { get; set; }
        public DbSet<Categoria> Categorie { get; set; }
        public DbSet<TipoArticolo> TipiArticolo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


        }
    }
}