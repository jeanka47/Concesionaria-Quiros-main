using Microsoft.AspNetCore.Mvc;
using ConcesionariaQuiros.Data;

namespace ConcesionariaQuiros.Controllers
{
    [ApiController]
    [Route("api/test")]
    public class TestConexionController : ControllerBase
    {
        private readonly ConcesionariaContext _context;

        public TestConexionController(ConcesionariaContext context)
        {
            _context = context;
        }

        [HttpGet("ping")]
        public IActionResult Ping()
        {
            try
            {
                // Solo intentamos acceder a la base de datos
                var puedeConectar = _context.Database.CanConnect();
                return Ok(new
                {
                    conectado = puedeConectar
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
