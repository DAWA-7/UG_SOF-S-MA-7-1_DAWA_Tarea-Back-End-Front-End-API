using System.ComponentModel.DataAnnotations;

namespace SOF_S_MA_7_1_TAREA_Back_End_Front_End_API.Models
{

    public class SUGERENCIA
    {
        [Key] public int id_sugerencia { get; set; }
        [Required] public string nombreLibro { get; set; }
        [Required] public string isbn { get; set; }
        [Required] public string autor { get; set; }
        [Required] public string fecha { get; set; }
        [Required] public int ci_solicitante { get; set; }

    }

}
