namespace P1Project.Models
{
    public class Orden
    {
        public int Id_Orden { get; set; }
        public int IdMesa { get; set; }
        public List<PlatoOrdenado> pedido { get; set; }
        public DateTime FechaOrden { get; set; }

    }
}
