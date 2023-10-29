using System.ComponentModel.DataAnnotations;

namespace P1Project.Models
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
