using ApiReseñaValoracion.DbContexts;
using ApiReseñaValoracion.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiReseñaValoracion.Repositories
{
    public class UsuarioRepository:IUsuarioRepository
    {
        private readonly AppDbContext bgcontext;

        public UsuarioRepository(AppDbContext bgcontext)
        {
            this.bgcontext = bgcontext;
        }
        public async Task<Usuario> ActualizarUsuario(Usuario usuario)
        {
            bgcontext.Usuarios.Update(usuario);
            await bgcontext.SaveChangesAsync();
            return usuario;

        }

        public async Task<Usuario> BuscarUsuarioPorId(int id)
        {
            var resenia = await bgcontext.Usuarios.Where(r => r.UsuarioId == id).FirstOrDefaultAsync();
            return resenia;
        }

        public async Task<Usuario> CrearUsuario(Usuario Usuario)
        {
            bgcontext.Usuarios.Add(Usuario);
            await bgcontext.SaveChangesAsync();
            return Usuario;
        }

        public async Task<bool> EliminarUsuario(int id)
        {
            var Usuario = await bgcontext.Usuarios.FirstOrDefaultAsync(c => c.UsuarioId == id);
            if (Usuario == null)
            {
                return false;
            }
            bgcontext.Usuarios.Remove(Usuario);
            await bgcontext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            return await bgcontext.Usuarios.ToListAsync();
        }
    }
}
