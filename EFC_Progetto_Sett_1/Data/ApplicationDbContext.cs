using EFC_Progetto_Sett_1.Models;
using Microsoft.EntityFrameworkCore;

namespace EFC_Progetto_Sett_1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Trasgressore> Trasgressori { get; set; }
        public DbSet<Violazione> Violazioni { get; set; }
        public DbSet<Verbale> Verbali { get; set; }
    }
}
