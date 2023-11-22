using ApiReseñaValoracion.Models;

namespace ApiReseñaValoracion.Repositories
{
    public interface IReseñaRepository
    {
        public Task<IEnumerable<Reseña>> GetResenas();
        public Task<Reseña> BuscarResenaPorId(int id);
        public Task<Reseña> CrearResena(Reseña resena);
        public Task<Reseña> ActualizarResena(Reseña resena);
        public Task<bool> EliminarResena(int id);
    }
}
