using Microsoft.EntityFrameworkCore;
using FreimyHidalgo_AP1_P2.Models;

namespace FreimyHidalgo_AP1_P2.DAL
{
        public class Context : DbContext
        {
            //Conexion con la base de datos (El contexto o context)
            public Context(DbContextOptions<Context> options) : base(options)
            {

            }
            public DbSet<Combo> Combo { get; set; }
            public DbSet<ComboDetalle> ComboDetalles { get; set; }
            public DbSet<Articulos> Articulo { get; set; }


            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                modelBuilder.Entity<Articulos>().HasData(new List<Articulos>()
        {
            new Articulos(){ArticuloId=1, Descripcion= "Memoria RAM ",Precio= 1200, },
            new Articulos(){ArticuloId=2, Descripcion= "Monitor ",Precio= 2000, },
            new Articulos(){ArticuloId=3, Descripcion= "CPU ",Precio= 1250, },

        });
            }


        }


    }

