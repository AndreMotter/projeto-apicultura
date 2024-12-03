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

        public DbSet<abe_raca> abe_raca { get; set; }
        public DbSet<abe_colmeia> abe_colmeia { get; set; }
        public DbSet<abe_apicultor> abe_apicultor { get; set; }
        public DbSet<abe_apiario> abe_apiario { get; set; }
        public DbSet<abe_apicultorcolmeia> abe_apicultorcolmeia { get; set; }
        public DbSet<abe_inspecao> abe_inspecao { get; set; }
        public DbSet<abe_leitura> abe_leitura { get; set; }
        public DbSet<abe_tipodeitura> abe_tipodeitura { get; set; }
        public DbSet<abe_unidademedida> abe_unidademedida { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<HistoricoAcessos> HistoricoAcessos { get; set; }
        public DbSet<Nfc> Nfc { get; set; }
    }
}
