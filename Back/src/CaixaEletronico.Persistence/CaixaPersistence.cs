using System.Linq;
using System.Threading.Tasks;
using CaixaEletronico.Domain;
using CaixaEletronico.Persistence.Contextos;
using CaixaEletronico.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;

namespace CaixaEletronico.Persistence
{
    public class CaixaPersistence : ICaixaPersistence
    {
        private readonly CaixaEletronicoContext _context;
    
        public CaixaPersistence(CaixaEletronicoContext context)
        {
            _context = context;
        }
        public async Task<Caixa> GetAllCaixaByIdAsync(int caixaId, bool includeNotas = false)
        {
            IQueryable<Caixa> query = _context.Caixas;

            if (includeNotas)
            {
                query
                    .Include(c => c.CaixaNotas)
                    .ThenInclude(CN => CN.Nota);
            }

            query = query.AsNoTracking().OrderBy(c => c.Id)
                        .Where(c => c.Id == caixaId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Caixa[]> GetAllCaixasAsync(bool includeNotas = false)
        {
            IQueryable<Caixa> query = _context.Caixas;

            if (includeNotas)
            {
                query.AsNoTracking()
                    .Include(c => c.CaixaNotas)
                    .ThenInclude(cn => cn.Nota);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

    }
}