using Microsoft.EntityFrameworkCore;

namespace WMVCADS2023.Models
{
    public class Contexto: DbContext
    {
        public Contexto(DbContextOptions<Contexto> options): base(options) { }

        public DbSet<Curso> Cursos { get; set; }
    }
}
