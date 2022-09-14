using System.ComponentModel.DataAnnotations;

namespace SOF_S_MA_7_1_TAREA_Back_End_Front_End_API.Models.Catalog
{
    public class Libro
    {
        [Key]
        public int IdLibro { get; set; }

        public Editorial? Editorial { get; set; }

        public Imagen? Imagen { get; set; }

        public List<Categoria>? Categoria { get; set; }

        public List<Autor>? Autor { get; set; }

        public DateTime FechaPublicacion { get; set; }

        public int NumPaginas { get; set; }

        public string? Isbn { get; set; }

        public string? Descripcion { get; set; }

        public string? Titulo { get; set; }

        public double? Precio { get; set; }

        public int? Cantidad { get; set; }

    }
}
