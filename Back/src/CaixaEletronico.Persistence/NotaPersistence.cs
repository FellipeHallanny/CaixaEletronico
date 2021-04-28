using System.Linq;
using System.Threading.Tasks;
using CaixaEletronico.Domain;
using CaixaEletronico.Persistence.Contextos;
using CaixaEletronico.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;

namespace CaixaEletronico.Persistence
{
    public class NotaPersistence : INotaPersistence
    {
        private readonly CaixaEletronicoContext _context;

        public NotaPersistence(CaixaEletronicoContext context)
        {
            _context = context;

        }
        public async Task<Nota> GetAllNotaByIdAsync(int notaId, bool includeCaixas = false)
        {
            IQueryable<Nota> query = _context.Notas;

            if (includeCaixas)
            {
                query
                    .Include(n => n.CaixaNotas)
                    .ThenInclude(CN => CN.Caixa);
            }

            query = query.AsNoTracking().OrderBy(c => c.Id)
                        .Where(n => n.Id == notaId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Nota[]> GetAllNotasAsync(bool includeCaixas = false)
        {
            IQueryable<Nota> query = _context.Notas;

            if (includeCaixas)
            {
                query.AsNoTracking()
                    .Include(n => n.CaixaNotas)
                    .ThenInclude(cn => cn.Caixa);
            }

            query = query.AsNoTracking().OrderBy(n => n.Id);

            return await query.ToArrayAsync();
        }
    }
}