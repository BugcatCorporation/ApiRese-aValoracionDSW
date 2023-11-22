using ApiReseñaValoracion.Models;

namespace ApiReseñaValoracion.Repositories
{
    public interface IValoracionRepository
    {
        public Task<IEnumerable<Valoracion>> GetValoraciones();
        public Task<Valoracion> BuscarValoracionPorId(int id);
        public Task<Valoracion> CrearValoracion(Valoracion valoracion);
        public Task<Valoracion> ActualizarValoracion(Valoracion valoracion);
        public Task<bool> EliminarValoracion(int id);
    }
}
