using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEBAPIRestaurante.Datos;
using WEBAPIRestaurante.Modelos;

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
        public async Task<IActionResult> CrearOrden(Orden nOrden)
        {
            Mesa m = await _dbOC.Mesas.FirstOrDefaultAsync(m => m.IdMesa == nOrden.IdMesa);
            if (m == null)
            {
                return BadRequest("No existe la mesa");
            }
            nOrden.IdMesa = m.IdMesa;                        

            await _dbOC.Mesas.AddAsync(m);
            await _dbOC.SaveChangesAsync();
            return Ok("Orden Creada");
        }



    }
}
