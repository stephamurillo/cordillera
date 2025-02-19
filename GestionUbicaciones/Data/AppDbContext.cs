using Microsoft.EntityFrameworkCore;

namespace GestionUbicaciones.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Ubicacion> Ubicaciones { get; set; }
    }
}
