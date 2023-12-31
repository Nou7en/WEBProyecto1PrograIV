﻿using System.ComponentModel.DataAnnotations;

namespace WEBAPIRestaurante.Modelos
{
    public class Orden
    {
        [Key] 
        public int Id_Orden { get; set; }
        public int IdMesa { get; set; }
        public List<PlatoOrdenado> pedido { get; set; }
        public DateTime FechaOrden { get; set; }

    }
}
