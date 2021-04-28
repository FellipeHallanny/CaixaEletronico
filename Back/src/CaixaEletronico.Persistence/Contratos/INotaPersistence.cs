using System.Threading.Tasks;
using CaixaEletronico.Domain;

namespace CaixaEletronico.Persistence.Contratos
{
    public interface INotaPersistence
    {
        Task<Nota[]> GetAllNotasAsync(bool includeCaixas = false);
        Task<Nota> GetAllNotaByIdAsync(int notaId,bool includeCaixas = false);
    }
}