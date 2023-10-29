namespace WEBAPIRestaurante.Modelos
{
    public class Factura
    {
        public Cliente Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public Orden Orden { get; set; }
    }
}
