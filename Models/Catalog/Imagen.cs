using System.ComponentModel.DataAnnotations;

namespace SOF_S_MA_7_1_TAREA_Back_End_Front_End_API.Models.Catalog
{
    public class Imagen
    {
        [Key]
        public int IdImagen { get; set; }

        public string? NombreImagen { get; set; }
    }
}
