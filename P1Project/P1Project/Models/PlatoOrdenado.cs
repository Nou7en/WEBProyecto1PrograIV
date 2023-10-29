using System.ComponentModel.DataAnnotations;

namespace P1Project.Models
{
    public class PlatoOrdenado
    {
        [Key]
        public int Id_PlatoOrdenado { get; set; }
        public int IdPlato { get; set; }
        public int Cantidad { get; set; }
        public bool Entregado { get; set; }

        public Plato plato { get; set; }
    }
}
