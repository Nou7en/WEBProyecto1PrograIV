using System.ComponentModel.DataAnnotations;

namespace P1Project.Models
{
    public class Mesa
    {
        [Key]
        public int IdMesa { get; set; }
        public int Id_Orden { get; set; }
        public bool Estado { get; set; }
        
    }
}
