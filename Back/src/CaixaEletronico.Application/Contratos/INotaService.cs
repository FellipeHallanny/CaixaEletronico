using System.Threading.Tasks;
using CaixaEletronico.Domain;

namespace CaixaEletronico.Application.Contratos
{
    public interface INotaService
    {
        Task<Nota> AddNotas(Nota model);
        Task<Nota> UpdateNotas(int NotaId, Nota model);
        Task<bool> DeleteNotas(int NotaId);

        Task<Nota[]> GetAllNotasAsync(bool includeCaixa = false);         
        Task<Nota> GetAllNotaByIdAsync(int NotaId,bool includeCaixa = false);
    }
}