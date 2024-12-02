using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Persistence
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

        //HoneyTrack
        public DbSet<abe_raca> abe_raca { get; set; }
        public DbSet<abe_colmeia> abe_colmeia { get; set; }


        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<CodigoAcesso> CodigoAcesso { get; set; }
        public DbSet<HistoricoAcessos> HistoricoAcessos { get; set; }
        public DbSet<Nfc> Nfc { get; set; }
    }
}
