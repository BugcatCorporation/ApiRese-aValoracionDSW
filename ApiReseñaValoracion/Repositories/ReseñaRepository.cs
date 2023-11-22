using ApiReseñaValoracion.DbContexts;
using ApiReseñaValoracion.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiReseñaValoracion.Repositories
{
    public class ReseñaRepository : IReseñaRepository
    {
        private readonly AppDbContext bgcontext;

        public ReseñaRepository(AppDbContext bgcontext)
        {
            this.bgcontext = bgcontext;
        }
        public async Task<Reseña> ActualizarResena(Reseña resena)
        {
            bgcontext.Resenas.Update(resena);
            await bgcontext.SaveChangesAsync();
            return resena;

        }

        public async Task<Reseña> BuscarResenaPorId(int id)
        {
            var resenia = await bgcontext.Resenas.Where(r => r.ReseñaId == id).Include(v => v.Valoracion).Include(u=>u.Usuario).FirstOrDefaultAsync();
            return resenia;
        }

        public async Task<Reseña> CrearResena(Reseña resena)
        {
            bgcontext.Resenas.Add(resena);
            await bgcontext.SaveChangesAsync();
            return resena;
        }

        public async Task<bool> EliminarResena(int id)
        {
            var resena = await bgcontext.Resenas.FirstOrDefaultAsync(c => c.ReseñaId == id);
            if (resena == null)
            {
                return false;
            }
            bgcontext.Resenas.Remove(resena);
            await bgcontext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Reseña>> GetResenas()
        {
            return await bgcontext.Resenas.Include(v => v.Valoracion).Include(u=>u.Usuario).ToListAsync();
        }
    }
}
