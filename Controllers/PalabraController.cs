using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PalabrasAlAzarESApi.Enums;
using PalabrasAlAzarESApi.Models;
using PalabrasAlAzarESApi.Services;

namespace PalabrasAlAzarESApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PalabraController : Controller
    {
        IPalabraService _palabraService;
        public PalabraController(IPalabraService palabraService)
        {
            _palabraService = palabraService;
        }

        [HttpGet("todas")]
        public IActionResult GetPalabras()
        {
            return Ok(_palabraService.GetPalabrasJson());
        }

        [HttpGet("{id}")]
        public IActionResult GetPalabra(int id) 
        {

            var palabra = _palabraService.GetPalabra(id);
            if(palabra is not null)
            {
                return Ok(palabra);
            }
            return NotFound();

        }


        [HttpGet("alAzar")]
        public IActionResult GetPalabraAlAzar() 
        {
            var palabra = _palabraService.GetPalabraAlAzar();
            if (palabra is not null)
            {
                return Ok(palabra);
            }
            return NotFound();
        }

        [HttpPost("CrearJson")]
        public IActionResult PostGenerarArchivo() {

            return Ok(_palabraService.GuardarJsonInicial());
            
        }

    }
}
