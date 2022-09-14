using System.ComponentModel.DataAnnotations;

namespace SOF_S_MA_7_1_TAREA_Back_End_Front_End_API.Models;

public class Usuarios
{
    [Key] public int USUARIOID { get; set; }
    [Required] 
    public string USERNAME { get; set; }        
    [Required] 
    public string PASSWORD { get; set; }
}