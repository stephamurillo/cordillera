using Microsoft.AspNetCore.Mvc;
using GestionUbicaciones.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionUbicaciones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UbicacionesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UbicacionesController(AppDbContext context)
        {
            _context = context;
        }

        // Obtener todas las ubicaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ubicacion>>> GetUbicaciones()
        {
            return await _context.Ubicaciones.ToListAsync();
        }

        // Obtener una ubicación por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Ubicacion>> GetUbicacion(int id)
        {
            var ubicacion = await _context.Ubicaciones.FindAsync(id);
            if (ubicacion == null)
                return NotFound();

            return ubicacion;
        }

        // Crear una nueva ubicación
        [HttpPost]
        public async Task<ActionResult<Ubicacion>> PostUbicacion(Ubicacion ubicacion)
        {
            _context.Ubicaciones.Add(ubicacion);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUbicacion), new { id = ubicacion.Id }, ubicacion);
        }

        // Actualizar una ubicación
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUbicacion(int id, Ubicacion ubicacion)
        {
            if (id != ubicacion.Id)
                return BadRequest();

            _context.Entry(ubicacion).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Eliminar una ubicación
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUbicacion(int id)
        {
            var ubicacion = await _context.Ubicaciones.FindAsync(id);
            if (ubicacion == null)
                return NotFound();

            _context.Ubicaciones.Remove(ubicacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}