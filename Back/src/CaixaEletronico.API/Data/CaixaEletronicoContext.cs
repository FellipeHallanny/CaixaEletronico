using CaixaEletronico.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CaixaEletronico.API.Data
{
    public class CaixaEletronicoContext : DbContext
    {

        public CaixaEletronicoContext(DbContextOptions<CaixaEletronicoContext> options) 
            : base(options)  { }
        public DbSet<Nota> Notas { get; set; }
    }
}