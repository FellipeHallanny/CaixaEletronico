using System.Threading.Tasks;
using CaixaEletronico.Persistence.Contextos;
using CaixaEletronico.Persistence.Contratos;

namespace CaixaEletronico.Persistence
{
    public class GeralPersistence : IGeralPersistence
    {
        private readonly CaixaEletronicoContext _context;

        public GeralPersistence(CaixaEletronicoContext context)
        {
            _context = context;

        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}