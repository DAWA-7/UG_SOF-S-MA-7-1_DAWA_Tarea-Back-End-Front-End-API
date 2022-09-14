using System.ComponentModel.DataAnnotations;

namespace SOF_S_MA_7_1_TAREA_Back_End_Front_End_API.Models.Catalog
{
    public class Editorial
    {
        [Key]
        public int IdEditorial { get; set; }

        public string? NombreEditorial { get; set; }
    }
}
