using MvcApplication1.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcApplicattion1.RepositorioEF
{
    public class Contexto: DbContext
    {
        public Contexto()
            :base("RestauranteConfig")
        {

        }

        public DbSet<Prato> Pratos { get; set; }

        public DbSet<Restaurante> Restaurantes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Prato>().Property(x => x.NomeRestaurante).IsRequired().HasColumnType("nchar").HasMaxLength(50);
            modelBuilder.Entity<Prato>().Property(x => x.Nome).IsRequired().HasColumnType("nchar").HasMaxLength(30);
            modelBuilder.Entity<Prato>().Property(x => x.Preco).IsRequired().HasColumnType("float");
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilderR)
        //{
        //    modelBuilderR.Conventions.Remove<PluralizingTableNameConvention>();

        //    modelBuilderR.Entity<Restaurante>().Property(x => x.Nome).IsRequired().HasColumnType("nchar").HasMaxLength(30);
        //}
    }
}
