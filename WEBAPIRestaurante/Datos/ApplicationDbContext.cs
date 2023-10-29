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
        }
    }
}
