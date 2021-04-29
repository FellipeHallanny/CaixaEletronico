using System;
using System.Threading.Tasks;
using CaixaEletronico.Application.Contratos;
using CaixaEletronico.Domain;
using CaixaEletronico.Persistence.Contratos;

namespace CaixaEletronico.Application
{
    public class CaixaService : ICaixaService
    {
        private readonly IGeralPersistence _geralPersistence;
        private readonly ICaixaPersistence _caixaPersistence;

        public CaixaService(IGeralPersistence geralPersistence, ICaixaPersistence caixaPersistence)
        {
            _caixaPersistence = caixaPersistence;
            _geralPersistence = geralPersistence;

        }      

        public async Task<Caixa> AddCaixas(Caixa model)
        {
            try
            {
                _geralPersistence.Add<Caixa>(model);

                if(await _geralPersistence.SaveChangesAsync())
                {
                    return await _caixaPersistence.GetAllCaixaByIdAsync(model.Id, false);
                }

                return null;

            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Caixa> UpdateCaixas(int caixaId, Caixa model)
        {
            try
            {
                var caixa = await _caixaPersistence.GetAllCaixaByIdAsync(caixaId,false);
                if(caixa == null) return null;

                model.Id = caixa.Id;

                _geralPersistence.Update(model);
                if(await _geralPersistence.SaveChangesAsync())
                {
                    return await _caixaPersistence.GetAllCaixaByIdAsync(model.Id, false);
                }
                return null;

            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteCaixas(int caixaId)
        {
            try
            {
                var caixa = await _caixaPersistence.GetAllCaixaByIdAsync(caixaId,false);
                if(caixa == null) throw new Exception("caixa para delete não foi encontrado!");

                _geralPersistence.Delete<Caixa>(caixa);

                return await _geralPersistence.SaveChangesAsync();         
        

            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Caixa> GetAllCaixaByIdAsync(int caixaId, bool includeNotas = false)
        {
            try
            {
                var caixa = await _caixaPersistence.GetAllCaixaByIdAsync(caixaId,includeNotas);
                if (caixa == null) return null;
                
                return caixa;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Caixa[]> GetAllCaixasAsync(bool includeNotas = false)
        {
            try
            {
                var caixas = await _caixaPersistence.GetAllCaixasAsync(includeNotas);
                if (caixas == null) return null;

                return caixas;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Caixa> MudarStatusCaixaAsync(int caixaId)
        {
            try
            {
                var caixa = await _caixaPersistence.GetAllCaixaByIdAsync(caixaId,false);
                if(caixa == null) return null;

                caixa.IsAtivo = !caixa.IsAtivo;

                _geralPersistence.Update(caixa);
                if(await _geralPersistence.SaveChangesAsync())
                {
                    return await _caixaPersistence.GetAllCaixaByIdAsync(caixa.Id, false);
                }
                return null;

            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }
    }
}