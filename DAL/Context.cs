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
            public DbSet<Combo1> Combo1 { get; set; }
            public DbSet<CombosDetalle> CombosDetalles { get; set; }
            public DbSet<Producto> Producto { get; set; }


            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                modelBuilder.Entity<Producto>().HasData(new List<Producto>()
        {
            new Producto(){ArticuloId=1, Descripcion= "Memoria RAM " ,Precio= 1200, Costo = 3400, existencia = 55},
            new Producto(){ArticuloId=2, Descripcion= "Monitor ",Precio= 2000, Costo = 5000, existencia = 28 }, 
            new Producto(){ArticuloId=3, Descripcion= "CPU ",Precio= 1250, Costo = 4300, existencia = 40 },

        });
            }


        }


    }

