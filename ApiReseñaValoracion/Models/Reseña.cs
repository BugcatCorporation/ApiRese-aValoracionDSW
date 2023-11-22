namespace ApiReseñaValoracion.Models
{
    public partial class Reseña
    {
        public int ReseñaId { get; set; }
        public int UsuarioId { get; set; }
        public string? Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public int ValoracionId {  get; set; }
        public Valoracion? Valoracion { get; set; }
        public Usuario? Usuario { get; set; }

    }
}
