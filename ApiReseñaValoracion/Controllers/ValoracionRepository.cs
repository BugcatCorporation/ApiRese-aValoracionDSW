using ApiReseñaValoracion.Models;
using ApiReseñaValoracion.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiValoracionValoracion.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ValoracionRepository : ControllerBase
    {
        private readonly IValoracionRepository vr;
        public ValoracionRepository(IValoracionRepository vr)
        {
            this.vr = vr;
        }
        [HttpGet]
        [Route("ListarValoraciones")]
        public async Task<ActionResult<IEnumerable<Valoracion>>> GetValoraciones()
        {
            return StatusCode(StatusCodes.Status200OK, await vr.GetValoraciones());

        }

        [HttpGet]
        [Route("ObtenerValoracionPorID/{id}")]
        public async Task<ActionResult<Valoracion>> BuscarValoracionPorId(int id)
        {
            return StatusCode(StatusCodes.Status200OK, await vr.BuscarValoracionPorId(id));
        }

        [HttpPost]
        [Route("CrearValoracion")]
        public async Task<ActionResult<Valoracion>> CrearValoracion(Valoracion valoracion)
        {
            return StatusCode(StatusCodes.Status201Created, await vr.CrearValoracion(valoracion));
        }

        [HttpPut]
        [Route("ActualizarValoracion")]
        public async Task<ActionResult<Valoracion>> ActualizarValoracion(Valoracion valoracion)
        {
            return StatusCode(StatusCodes.Status200OK, await vr.ActualizarValoracion(valoracion));
        }

        [HttpDelete]
        [Route("EliminarValoracion")]
        public async Task<ActionResult<bool>> EliminarValoracion(int id)
        {
            return StatusCode(StatusCodes.Status200OK, await vr.EliminarValoracion(id));
        }
    }
}
