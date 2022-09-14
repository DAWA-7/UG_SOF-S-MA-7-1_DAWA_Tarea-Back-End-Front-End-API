using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace SOF_S_MA_7_1_TAREA_Back_End_Front_End_API.Models.Catalog
{
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }

        public string NombreCategoria { get; set; }

        [JsonIgnore]
        public List<Libro>? Libro { get; set; }

    }

    public class CategoriaLibro
    {
        [Key]
        public int IdCategoriaLibro { get; set; }

        public int CategoriaIdCategoria { get; set; }
        public Categoria Categoria { get; set; }

        public int LibroIdLibro { get; set; }
        public Libro? Libro { get; set; }
    }
}
