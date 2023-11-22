using ApiReseñaValoracion.Models;
using Microsoft.EntityFrameworkCore;
namespace ApiReseñaValoracion.DbContexts
{
    public class AppDbContext: DbContext
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions options) : base(options) 
        {
        }
        public DbSet<Reseña>Resenas { get; set; }
        public DbSet<Valoracion> Valoraciones { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
