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

    }
}
