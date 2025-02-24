using KeraNaidi.Data.Models;
using KeraNaidi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KeraNaidi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UbicacionController : ControllerBase
    {
        private readonly IUbicacionService _ubicacionService;
        public UbicacionController(IUbicacionService ubicacionService)
        {
            _ubicacionService = ubicacionService;
        }

        // GET: api/Ubicacion
        [HttpGet]
        public async Task<IActionResult> GetUbicaciones()
        {
            var ubicaciones = await _ubicacionService.GetAllAsync();
            return Ok(ubicaciones);
        }

        // GET: api/Ubicacion/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUbicacion(int id)
        {
            var ubicacion = await _ubicacionService.GetByIdAsync(id);
            if (ubicacion == null)
            {
                return NotFound();
            }
            return Ok(ubicacion);
        }

        // POST: api/Ubicacion
        [HttpPost]
        public async Task<IActionResult> CreateUbicacion([FromBody] Ubicacion ubicacion)
        {
            if (ubicacion == null)
            {
                return BadRequest();
            }

            await _ubicacionService.AddAsync(ubicacion);
            return CreatedAtAction(nameof(GetUbicacion), new { id = ubicacion.Id }, ubicacion);
        }

        // PUT: api/Ubicacion/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUbicacion(int id, [FromBody] Ubicacion ubicacion)
        {
            if (ubicacion == null || id != ubicacion.Id)
            {
                return BadRequest();
            }

            var updatedUbicacion = await _ubicacionService.UpdateAsync(ubicacion);
            if (updatedUbicacion == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/Ubicacion/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUbicacion(int id)
        {
            var deleted = await _ubicacionService.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
