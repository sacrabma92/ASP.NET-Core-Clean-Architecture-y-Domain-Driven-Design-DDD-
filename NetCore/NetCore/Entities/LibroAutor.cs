namespace NetCore.Entities
{
    public class LibroAutor
    {
        public int AutorId { get; set; }
        public int LibroId { get; set; }
        public Autor Autor { get; set; }
        public Libro Libro { get; set; }
    }
}
