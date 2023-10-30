using Microsoft.EntityFrameworkCore;
using WEBAPIRestaurante.Modelos;

namespace WEBAPIRestaurante.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
            
        }
        public DbSet<Plato> Menu { get; set; }
        public DbSet<PlatoOrdenado> PlatosOrdenados { get; set; }
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<Mesa> Mesas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plato>().HasData(
                    new Plato()
                    {
                        IdPlato = 1,
                        Nombre = "Chaulafan",
                        Descripcion = "Arroz Frito al estilo Chino muy rico",
                        Precio = 4.50,
                        ImagenUrl = "",
                    },
                    new Plato()
                    {
                        IdPlato = 2,
                        Nombre = "Mixto",
                        Descripcion = "Arroz y Tallarin la mejor combi",
                        Precio = 6.00,
                        ImagenUrl = "",
                    }
               );
            modelBuilder.Entity<Mesa>().HasData(
                new Mesa()
                {
                    IdMesa = 1,
                    Id_Orden = 0,
                    Estado = false,
                },
                    new Mesa()
                    {
                        IdMesa = 2,
                        Id_Orden = 0,
                        Estado = false,
                    },
                    new Mesa()
                    {
                        IdMesa = 3,
                        Id_Orden = 0,
                        Estado = false,
                    },
                    new Mesa()
                    {
                        IdMesa = 4,
                        Id_Orden = 0,
                        Estado = false,
                    },
                    new Mesa()
                    {
                        IdMesa = 5,
                        Id_Orden = 0,
                        Estado = false,
                    },
                    new Mesa()
                    {
                        IdMesa = 6,
                        Id_Orden = 0,
                        Estado = false,
                    }

                );
        }
    }
}
