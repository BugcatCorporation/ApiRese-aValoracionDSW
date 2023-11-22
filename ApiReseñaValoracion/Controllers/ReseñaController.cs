using ApiReseñaValoracion.Models;
using ApiReseñaValoracion.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace ApiReseñaValoracion.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ReseñaController:ControllerBase
    {
        private readonly IReseñaRepository rr;
        public ReseñaController(IReseñaRepository rr)
        {
            this.rr = rr;
        }
        [HttpGet]
        [Route("ListarResenas")]
        public async Task<ActionResult<IEnumerable<Reseña>>> GetResenas()
        {
            return StatusCode(StatusCodes.Status200OK, await rr.GetResenas());

        }
        
        [HttpGet]
        [Route("ObtenerResenaPorID/{id}")]
        public async Task<ActionResult<Reseña>> BuscarResenaPorId(int id)
        {
            return StatusCode(StatusCodes.Status200OK, await rr.BuscarResenaPorId(id));
        }    

        [HttpPost]
        [Route("CrearResena")]
        public async Task<ActionResult<Reseña>> CrearResena(Reseña Resena)
        {
            return StatusCode(StatusCodes.Status201Created, await rr.CrearResena(Resena));
        }

        [HttpPut]
        [Route("ActualizarResena")]
        public async Task<ActionResult<Reseña>> ActualizarResena(Reseña Resena)
        {
            return StatusCode(StatusCodes.Status200OK, await rr.ActualizarResena(Resena));
        }

        [HttpDelete]
        [Route("EliminarResena")]
        public async Task<ActionResult<bool>> EliminarResena(int id)
        {
            return StatusCode(StatusCodes.Status200OK, await rr.EliminarResena(id));
        }
    }
}
