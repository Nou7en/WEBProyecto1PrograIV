using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEBAPIRestaurante.Datos;
using WEBAPIRestaurante.Modelos;

namespace WEBAPIRestaurante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatoController : ControllerBase
    {
        private readonly ILogger<PlatoController> _logger;
        private readonly ApplicationDbContext _db;
        public PlatoController(ILogger<PlatoController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;

        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Plato>>> GetPlatos()
        {
            _logger.LogInformation("Obtener los Platos");
            return Ok(await _db.Menu.ToListAsync());
        }


        [HttpGet("IdPlato:int", Name = "GetPlato")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Plato>> GetPlato(int Id)
        {
            if (Id == 0)
            {
                _logger.LogError("Error al obtener plato con Id" + Id);
                return BadRequest();
            }
            //Plato plato = Menu.ListaPlatos.FirstOrDefault(p => p.IdPlato == Id);
            Plato plato = await _db.Menu.FirstOrDefaultAsync(p => p.IdPlato == Id);

            if (plato == null)
            {
                return NotFound();
            }
            return Ok(plato);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Plato>> CrearPlato(Plato nplato)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            if ( await _db.Menu.FirstOrDefaultAsync(p => p.Nombre.ToLower() == nplato.Nombre.ToLower()) != null)
            {
                ModelState.AddModelError("NombreExistente", "El nombre de plato ya existe");
                return BadRequest(ModelState);
            }
            if (nplato == null)
            {
                return BadRequest();
            }
            if (nplato.IdPlato > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            Plato modelo = new()
            {
     
                Nombre = nplato.Nombre,
                Descripcion = nplato.Descripcion,
                Precio = nplato.Precio,
                ImagenUrl = nplato.ImagenUrl,
            };

            await _db.Menu.AddAsync(modelo);
            await _db.SaveChangesAsync();

            return CreatedAtRoute("GetPlato", new { IdPlato = nplato.IdPlato }, nplato);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePlato(int id)
        {

            if (id == 0)
            {
                return BadRequest();
            }
            Plato plato = await _db.Menu.FirstOrDefaultAsync(p => p.IdPlato == id);

            if (plato == null)
            {
                return NotFound();
            }
            _db.Menu.Remove(plato);
            await _db.SaveChangesAsync();

            return NoContent();


        }

        [HttpPut("{id:int}")]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> EditarPlato(int id, Plato eplato)
        {
            if (eplato == null || id != eplato.IdPlato )
            {
                return BadRequest();
            }

            Plato modelo = new()
            {
                IdPlato = eplato.IdPlato,
                Nombre = eplato.Nombre,
                Descripcion = eplato.Descripcion,
                Precio = eplato.Precio,
                ImagenUrl = eplato.ImagenUrl,
            };
            _db.Menu.Update(modelo);
            await _db.SaveChangesAsync();
           
            return NoContent();

        }

        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> EditarAEspecificoPlato(int id, JsonPatchDocument<Plato> pplato)
        {
            if (pplato == null || id == 0)
            {
                return BadRequest();
            }
            Plato plato = await _db.Menu.AsNoTracking().FirstOrDefaultAsync(p => p.IdPlato == id);

            Plato mplato = new()
            {
                IdPlato = plato.IdPlato,
                Nombre = plato.Nombre,
                Descripcion = plato.Descripcion,
                Precio = plato.Precio,
                ImagenUrl = plato.ImagenUrl,
            };

            if (plato == null) return BadRequest();

            pplato.ApplyTo(mplato, ModelState);

            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Plato modelo = new()
            {
                IdPlato = mplato.IdPlato,
                Nombre = mplato.Nombre,
                Descripcion = mplato.Descripcion,
                Precio = mplato.Precio,
                ImagenUrl = mplato.ImagenUrl,
            };

            _db.Menu.Update(modelo);
            await _db.SaveChangesAsync(); 

            return NoContent();

        }

    }
}
