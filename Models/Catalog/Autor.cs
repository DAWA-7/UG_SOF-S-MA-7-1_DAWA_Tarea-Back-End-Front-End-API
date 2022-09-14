using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SOF_S_MA_7_1_TAREA_Back_End_Front_End_API.Models.Catalog
{
    public class Autor
    {
        [Key]
        public int IdAutor { get; set; }

        public string NombreAutor { get; set; }

        public string ApellidoAutor { get; set; }

        [JsonIgnore]
        public List<Libro>? Libro { get; set; }

    }

    public class AutorLibro
    {
        [Key]
        public int IdAutorLibro { get; set; }

        public int AutorIdAutor { get; set; }
        public Autor Autor { get; set; }

        public int LibroIdLibro { get; set; }
        public Libro Libro { get; set; }

    }
}
