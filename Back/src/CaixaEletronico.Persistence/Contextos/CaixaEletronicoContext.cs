using CaixaEletronico.Domain;
using Microsoft.EntityFrameworkCore;

namespace CaixaEletronico.Persistence.Contextos
{
    public class CaixaEletronicoContext : DbContext
    {

        public CaixaEletronicoContext(DbContextOptions<CaixaEletronicoContext> options) 
            : base(options)  { }

        public DbSet<Nota> Notas { get; set; }
        public DbSet<Caixa> Caixas { get; set; }
        public DbSet<CaixaNota> CaixaNotas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CaixaNota>()
                .HasKey(CN => new {CN.CaixaId, CN.NotaId});
                
        }

    }
}