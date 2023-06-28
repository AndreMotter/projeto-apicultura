using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<CodigoAcesso> CodigoAcesso { get; set; }
        public DbSet<HistoricoAcessos> HistoricoAcessos { get; set; }
    }
}
