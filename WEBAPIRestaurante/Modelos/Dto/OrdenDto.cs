using System.ComponentModel.DataAnnotations;

namespace WEBAPIRestaurante.Modelos.Dto
{
    public class OrdenDto
    {
        public int Id_Orden { get; set; }
        public int IdMesa { get; set; }
        public DateTime FechaOrden { get; set; }
    }
}
