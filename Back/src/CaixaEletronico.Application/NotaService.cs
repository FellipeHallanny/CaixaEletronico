using System;
using System.Threading.Tasks;
using CaixaEletronico.Application.Contratos;
using CaixaEletronico.Domain;
using CaixaEletronico.Persistence.Contratos;

namespace CaixaEletronico.Application
{
    public class NotaService : INotaService
    {
        private readonly IGeralPersistence _geralPersistence;
        private readonly INotaPersistence _notaPersistence;

        public NotaService(IGeralPersistence geralPersistence, INotaPersistence notaPersistence)
        {
            _notaPersistence = notaPersistence;
            _geralPersistence = geralPersistence;

        }

        public async Task<Nota> AddNotas(Nota model)
        {            
            try
            {
                _geralPersistence.Add<Nota>(model);

                if(await _geralPersistence.SaveChangesAsync())
                {
                    return await _notaPersistence.GetAllNotaByIdAsync(model.Id, false);
                }

                return null;

            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteNotas(int notaId)
        {
           try
            {
                var nota = await _notaPersistence.GetAllNotaByIdAsync(notaId,false);
                if(nota == null) throw new Exception("Nota para delete não foi encontrada!");

                _geralPersistence.Delete<Nota>(nota);

                return await _geralPersistence.SaveChangesAsync();         
        

            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Nota> UpdateNotas(int notaId, Nota model)
        {
            try
            {
                var nota = await _notaPersistence.GetAllNotaByIdAsync(notaId,false);
                if(nota == null) return null;

                model.Id = nota.Id;

                _geralPersistence.Update(model);
                if(await _geralPersistence.SaveChangesAsync())
                {
                    return await _notaPersistence.GetAllNotaByIdAsync(model.Id, false);
                }
                return null;

            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Nota> GetAllNotaByIdAsync(int notaId, bool includeCaixa = false)
        {
            try
            {
                var nota = await _notaPersistence.GetAllNotaByIdAsync(notaId,includeCaixa);
                if (nota == null) return null;
                
                return nota;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Nota[]> GetAllNotasAsync(bool includeCaixa = false)
        {
           try
            {
                var notas = await _notaPersistence.GetAllNotasAsync(includeCaixa);
                if (notas == null) return null;

                return notas;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        
    }
}