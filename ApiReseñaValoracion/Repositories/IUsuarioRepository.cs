using ApiReseñaValoracion.Models;

namespace ApiReseñaValoracion.Repositories
{
    public interface IUsuarioRepository
    {
        public Task<IEnumerable<Usuario>> GetUsuarios();
        public Task<Usuario> BuscarUsuarioPorId(int id);
        public Task<Usuario> CrearUsuario(Usuario usuario);
        public Task<Usuario> ActualizarUsuario(Usuario usuario);
        public Task<bool> EliminarUsuario(int id);
    }
}
