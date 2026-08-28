using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrimeraWebApi.Data;
using PrimeraWebApi.Models;

namespace PrimeraWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CamionesController : ControllerBase
    {
        private readonly CamionerosDbContext _context;

        public CamionesController(CamionerosDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Camione>>> GetCamiones()
        {
            return await _context.Camiones.ToListAsync();
        }

        // GET: api/camiones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Camione>> GetCamion(int id)
        {
            var camion = await _context.Camiones.FindAsync(id);

            if (camion == null)
            {
                return NotFound();
            }

            return camion;
        }
    }
}