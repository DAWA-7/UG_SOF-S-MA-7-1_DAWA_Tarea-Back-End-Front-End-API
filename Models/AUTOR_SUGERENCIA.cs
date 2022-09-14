using System.ComponentModel.DataAnnotations;

namespace SOF_S_MA_7_1_TAREA_Back_End_Front_End_API.Models
{
    public class AUTOR_SUGERENCIA
    {
        [Key]
        public int AUTOR_SUGERENCIAID { get; set; }

        [Required]
        public string? NOMBRE_AUTOR { get; set; }

        [Required]
        public string? APELLIDO_AUTOR { get; set; }

        [Required]
        public DateTime FECHA_REGISTRO { get; set; }

        [Required] public ESTADO? ESTADO { get; set; }

    }


    public class AUTOR_SUGERENCIA_SUGERENCIA
    {
        [Key]
        public int AUTOR_SUGERENCIA_SUGERENCIAID { get; set; }


        [Required]
        public DateTime FECHA_REGISTRO { get; set; }

        [Required] public AUTOR_SUGERENCIA AUTOR { get; set; }

        [Required] public SUGERENCIA? SUGERENCIA { get; set; }

        [Required] public ESTADO? ESTADO { get; set; }

    }


    public class ESTADO
    {
        [Key]
        public int ESTADOID { get; set; }

        [Required] public string? NOMBRE_ESTADO { get; set; }
    }

    public class SUGERENCIA
    {
        [Key]
        public int SUGERENCIAID { get; set; }

        [Required] public USUARIO? USUARIO { get; set; }

        [Required] public string TITULO { get; set; }
        [Required] public string EDICION { get; set; }
        [Required] public string EDITORIAL { get; set; }
        [Required] public DateTime FECHA_PUBLICACION { get; set; }
        [Required] public string COMENTARIOS { get; set; }
        [Required] public DateTime FECHA_REGISTRO { get; set; }

        [Required] public ESTADO? ESTADO { get; set; }

    }

    public class USUARIO
    {
        [Key]
        public int USUARIOID { get; set; }

        [Required] public int ID_PERSONA { get; set; }
        [Required] public int ID_ROL { get; set; }
        [Required] public string? USERNAME { get; set; }
        [Required] public string? PASSWORD { get; set; }
        [Required] public DateTime FECHA_REGISTRO { get; set; }

        [Required] public ESTADO? ESTADO { get; set; }
    }
}
