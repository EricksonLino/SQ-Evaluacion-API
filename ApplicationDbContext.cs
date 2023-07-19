using Microsoft.EntityFrameworkCore;
using SQ_Evaluacion_API.Models;

namespace SQ_Evaluacion_API
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Formulario> Formularios { get; set; }
    }
}
