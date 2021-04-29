using System.Threading.Tasks;
using CaixaEletronico.Domain;

namespace CaixaEletronico.Application.Contratos
{
    public interface ICaixaService
    {
        Task<Caixa> AddCaixas(Caixa model);
        Task<Caixa> UpdateCaixas(int CaixaId, Caixa model);
        Task<bool> DeleteCaixas(int CaixaId);

        Task<Caixa[]> GetAllCaixasAsync(bool includeNotas = false);         
        Task<Caixa> GetAllCaixaByIdAsync(int CaixaId,bool includeNotas = false);
    }
}