using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace WEBAPIRestaurante.Modelos.Dto
{
    public class PlatoOrdenadoDto
    {
        public int Id_PlatoOrdenado { get; set; }
        public int IdPlato { get; set; }
        public int Cantidad { get; set; }
        public bool Entregado { get; set; }

    }
}
