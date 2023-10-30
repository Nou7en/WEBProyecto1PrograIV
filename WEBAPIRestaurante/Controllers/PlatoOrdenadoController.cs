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
    public class PlatoOrdenadoController : ControllerBase
    {
        private readonly ApplicationDbContext _dbPO;
        public PlatoOrdenadoController(ApplicationDbContext dbPO)
        {
            _dbPO = dbPO;
        }
        [HttpPost]
        public async Task<IActionResult> AgregarPlatoOrdenado(PlatoOrdenadoDto platoOrdenadoDto)
        {
            if (platoOrdenadoDto == null)
            {
                return BadRequest("El plato ordenado no existe");

            }
            Plato plato = await _dbPO.Menu.FirstOrDefaultAsync(po => po.IdPlato == platoOrdenadoDto.IdPlato);
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

            await _dbPO.PlatosOrdenados.AddAsync(platoOrdenado);
            await _dbPO.SaveChangesAsync();
            return Ok("platoOrdenado agregado correctamente");


        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult>IObtenerPlatoOrdenado(int id)
        {
            var platoOrdenado = await _dbPO.PlatosOrdenados.FirstOrDefaultAsync(po => po.Id_PlatoOrdenado == id);
            if (platoOrdenado == null)
            {
                return NoContent();
            }
            Plato plato = await _dbPO.Menu.FirstOrDefaultAsync(p => p.IdPlato == platoOrdenado.IdPlato);
            platoOrdenado.plato = plato;
            return Ok(platoOrdenado);
        }

        [HttpDelete("{id:int}")]
        public IActionResult EliminarPlatoOrdenado(int id)
        {
            var platoOrdenado = _dbPO.PlatosOrdenados.FirstOrDefault(po => po.Id_PlatoOrdenado == id);

            if (platoOrdenado == null)
            {
                return NotFound("Plato ordenado no encontrado.");
            }

            _dbPO.PlatosOrdenados.Remove(platoOrdenado);
            _dbPO.SaveChanges();

            return Ok("Plato ordenado eliminado exitosamente.");
        }




    }
}
