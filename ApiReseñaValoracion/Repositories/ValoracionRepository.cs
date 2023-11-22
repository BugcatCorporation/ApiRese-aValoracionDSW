using ApiReseñaValoracion.DbContexts;
using ApiReseñaValoracion.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiReseñaValoracion.Repositories
{
    public class ValoracionRepository:IValoracionRepository
    {
        private readonly AppDbContext bgcontext;

        public ValoracionRepository(AppDbContext bgcontext)
        {
            this.bgcontext = bgcontext;
        }
        public async Task<Valoracion> ActualizarValoracion(Valoracion Valoracion)
        {
            bgcontext.Valoraciones.Update(Valoracion);
            await bgcontext.SaveChangesAsync();
            return Valoracion;

        }

        public async Task<Valoracion> BuscarValoracionPorId(int id)
        {
            var valoracion = await bgcontext.Valoraciones.Where(v => v.ValoracionId == id).FirstOrDefaultAsync();
            return valoracion;
        }

        public async Task<Valoracion> CrearValoracion(Valoracion Valoracion)
        {
            bgcontext.Valoraciones.Add(Valoracion);
            await bgcontext.SaveChangesAsync();
            return Valoracion;
        }

        public async Task<bool> EliminarValoracion(int id)
        {
            var Valoracion = await bgcontext.Valoraciones.FirstOrDefaultAsync(c => c.ValoracionId == id);
            if (Valoracion == null)
            {
                return false;
            }
            bgcontext.Valoraciones.Remove(Valoracion);
            await bgcontext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Valoracion>> GetValoraciones()
        {
            return await bgcontext.Valoraciones.ToListAsync();
        }
    }
}
