using LaGata.Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LaGata.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        private readonly LaGataDbContext _db;
        public HealthController(LaGataDbContext db) => _db = db;

        [HttpGet("db")]
        public async Task<IActionResult> CheckDb()
        {
            try
            {
                // Simple ping using SELECT 1
                var result = await _db.Database.ExecuteSqlRawAsync("SELECT 1");
                return Ok(new { ok = true });
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { ok = false, error = ex.Message });
            }
        }
    }
}


