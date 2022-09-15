
using Microsoft.EntityFrameworkCore;
using SOF_S_MA_7_1_TAREA_Back_End_Front_End_API.Models;
using SOF_S_MA_7_1_TAREA_Back_End_Front_End_API.Models.Catalog;

namespace SOF_S_MA_7_1_TAREA_Back_End_Front_End_API.Data
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
        public DbSet<Libro> Libro { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<CategoriaLibro> CategoriaLibro { get; set; }
        public DbSet<Autor> Autor { get; set; }
        public DbSet<AutorLibro> AutorLibro { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Libro>()
                .HasMany(c => c.Categoria)
                .WithMany(l => l.Libro)
                .UsingEntity<CategoriaLibro>(
                lc => lc.HasOne(prop => prop.Categoria)
                .WithMany()
                .HasForeignKey(prop => prop.CategoriaIdCategoria),
                lc => lc.HasOne(prop => prop.Libro)
                .WithMany()
                .HasForeignKey(prop => prop.LibroIdLibro)
                );
            modelBuilder.Entity<Libro>()
                .HasMany(a => a.Autor)
                .WithMany(l => l.Libro)
                .UsingEntity<AutorLibro>(
                lc => lc.HasOne(prop => prop.Autor)
                .WithMany()
                .HasForeignKey(prop => prop.AutorIdAutor),
                lc => lc.HasOne(prop => prop.Libro)
                .WithMany()
                .HasForeignKey(prop => prop.LibroIdLibro)
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
