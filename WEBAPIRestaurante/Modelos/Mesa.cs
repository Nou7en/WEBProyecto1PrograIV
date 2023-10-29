using System.ComponentModel.DataAnnotations;

namespace WEBAPIRestaurante.Modelos
{
    public class Mesa
    {
        [Key]
        public int IdMesa { get; set; }
        public int Id_Orden { get; set; }
        public bool Estado { get; set; }
        
    }
}
