namespace NetCore.Entities
{
    public class Libro
    {
        public int LibroId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public Precio? PrecioPromocion { get; set; }
        //Collecion de comentarios
        public ICollection<Comentario>? ComentarioLista { get; set; }
        public ICollection<LibroAutor> AutorLink { get; set; }
    }
}
