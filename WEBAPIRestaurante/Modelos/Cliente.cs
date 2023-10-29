using System.ComponentModel.DataAnnotations;

namespace WEBAPIRestaurante.Modelos
{
    public class Cliente
    {
        [Key]
        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public string telefono { get; set; }
        public string Direccion { get; set; }
    }
}
