using Microsoft.EntityFrameworkCore;
using SOF_S_MA_7_1_TAREA_Back_End_Front_End_API.Models;

namespace APIClientes.Data
{
    public class ApplicationDbContext : DbContext
    {   
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Usuarios> Usuario { get; set; }
        public DbSet<AUTOR_SUGERENCIA> AUTOR_SUGERENCIA { get; set; }
        public DbSet<AUTOR_SUGERENCIA_SUGERENCIA> AUTOR_SUGERENCIA_SUGERENCIA { get; set; }
        public DbSet<ESTADO> ESTADO { get; set; }
        public DbSet<SUGERENCIA> SUGERENCIA { get; set; }
        public DbSet<USUARIO> USUARIO { get; set; }

    }
}
