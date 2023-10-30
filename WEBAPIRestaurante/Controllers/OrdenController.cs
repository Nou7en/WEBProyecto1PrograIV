using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEBAPIRestaurante.Datos;
using WEBAPIRestaurante.Modelos;
using WEBAPIRestaurante.Modelos.Dto;

namespace WEBAPIRestaurante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenController : ControllerBase
    {
        private readonly ApplicationDbContext _dbOC;
        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObtenerOrden(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var orden = _dbOC.Ordenes.FirstOrDefaultAsync(o => o.Id_Orden == id);

            if (orden == null)
            {
                return NoContent();
            }

            return Ok(orden);
        }

        [HttpPost]
        public async Task<IActionResult> CrearOrden([FromBody] OrdenDto ordenDto)
        {
            Mesa m = await _dbOC.Mesas.FirstOrDefaultAsync(m => m.IdMesa == ordenDto.IdMesa);
            if (m == null)
            {
                return BadRequest("No existe la mesa");
            }
            Orden orden = new Orden
            {
                FechaOrden = DateTime.Now,
                IdMesa = ordenDto.IdMesa,
                Id_Orden = ordenDto.Id_Orden,
                pedido = null

            };
            await _dbOC.Ordenes.AddAsync(orden);
            await _dbOC.SaveChangesAsync();
            return Ok("Orden Creada");
        }

        [HttpPost("id:int")]
        public async Task<IActionResult> AgregarPlatoOrdenadoAOrden(int idOrden, [FromBody] PlatoOrdenadoDto platoOrdenadoDto)
        {
            Orden orden = await _dbOC.Ordenes.FirstOrDefaultAsync(o => o.Id_Orden == idOrden);

            if (orden == null)
            {
                return BadRequest("La orden no existe");
            }

            if (platoOrdenadoDto == null)
            {
                return BadRequest("El plato ordenado no existe");
            }

            Plato plato = await _dbOC.Menu.FirstOrDefaultAsync(po => po.IdPlato == platoOrdenadoDto.IdPlato);

            if (plato == null)
            {
                return BadRequest("Plato no existe");
            }

            PlatoOrdenado platoOrdenado = new PlatoOrdenado
            {
                Cantidad = platoOrdenadoDto.Cantidad,
                IdPlato = platoOrdenadoDto.IdPlato,
                Id_PlatoOrdenado = platoOrdenadoDto.Id_PlatoOrdenado,
                Entregado = platoOrdenadoDto.Entregado,
                plato = plato
            };

            // Agregar el plato ordenado a la lista de pedidos de la orden
            orden.pedido.Add(platoOrdenado);

            await _dbOC.SaveChangesAsync();
            return Ok("PlatoOrdenado agregado a la orden correctamente");
        }




    }
}
