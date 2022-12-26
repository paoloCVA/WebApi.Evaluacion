using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Evaluacion.Model;
using WebApi.Evaluacion.Persistencia;

namespace WebApi.Evaluacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatosController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Datos srvDato = new Datos();
            return Ok(srvDato.ObtenerDatos());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Datos srvDato = new Datos();
            var dt = srvDato.ObtenerDato(id);

            if (dt==null)
            {
                var nf = NotFound("La empresa " + id.ToString() + " no existe.");
                return nf;
            }

            return Ok(dt);
        }

        [HttpPost("agregar")]
        public IActionResult AgregarEmpresa(Dato newDato)
        {
            Datos srvDato = new Datos();
            srvDato.Agregar(newDato);

            return CreatedAtAction(nameof(AgregarEmpresa), newDato);
        }

        [HttpGet("eliminar/{id}")]
        public IActionResult Eliminar(int id)
        {
            Datos srvDato = new Datos();
            bool bDato = srvDato.Eliminar(id);

            if (bDato)
            {
                return Ok(srvDato.ObtenerDatos());
            }
            else
            {
                return BadRequest("Ocurrió un error al eliminar el ID = " + id.ToString());
            }
        }

        [HttpPost("actualizar")]
        public IActionResult ActualizarEmpresa(Dato updDato)
        {
            Datos srvDato = new Datos();

            var dt = srvDato.ObtenerDato(updDato.Id);

            if (dt == null)
            {
                var nf = NotFound("La empresa " + updDato.Id.ToString() + " no existe.");
                return nf;
            }
            srvDato.Actualizar(updDato);
            return Ok(dt);
        }
    }
}
