using System.Threading.Tasks;
using CaixaEletronico.Domain;

namespace CaixaEletronico.Persistence.Contratos
{
    public interface ICaixaPersistence
    {
        Task<Caixa[]> GetAllCaixasAsync(bool includeNotas = false);
        Task<Caixa> GetAllCaixaByIdAsync(int caixaId,bool includeNotas = false); 
    }
}