using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBAPIRestaurante.Modelos
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
