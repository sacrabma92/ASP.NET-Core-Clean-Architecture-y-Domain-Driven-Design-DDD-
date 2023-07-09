namespace NetCore.Entities
{
    public class Comentario
    {
        public int ComentarioId { get; set; }
        public string Alumno { get; set; }
        public int Puntaje { get; set; }
        public string ComentarioTexto { get; set; }
        public int LibroId { get; set; }
        // Clase ancla de libro
        public Libro Libro { get; set; }
    }
}
