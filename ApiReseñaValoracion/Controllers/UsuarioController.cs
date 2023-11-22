using ApiReseñaValoracion.Models;
using ApiReseñaValoracion.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiUsuarioValoracion.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsuarioController:ControllerBase
    {
        private readonly IUsuarioRepository ur;
        public UsuarioController(IUsuarioRepository ur)
        {
            this.ur = ur;
        }

        [HttpGet]
        [Route("ListarUsuarios")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return StatusCode(StatusCodes.Status200OK, await ur.GetUsuarios());

        }

        [HttpGet]
        [Route("ObtenerUsuarioPorID/{id}")]
        public async Task<ActionResult<Usuario>> BuscarUsuarioPorId(int id)
        {
            return StatusCode(StatusCodes.Status200OK, await ur.BuscarUsuarioPorId(id));
        }

        [HttpPost]
        [Route("CrearUsuario")]
        public async Task<ActionResult<Usuario>> CrearUsuario(Usuario Usuario)
        {
            return StatusCode(StatusCodes.Status201Created, await ur.CrearUsuario(Usuario));
        }

        [HttpPut]
        [Route("ActualizarUsuario")]
        public async Task<ActionResult<Usuario>> ActualizarUsuario(Usuario Usuario)
        {
            return StatusCode(StatusCodes.Status200OK, await ur.ActualizarUsuario(Usuario));
        }

        [HttpDelete]
        [Route("EliminarUsuario")]
        public async Task<ActionResult<bool>> EliminarUsuario(int id)
        {
            return StatusCode(StatusCodes.Status200OK, await ur.EliminarUsuario(id));
        }
    }
}
