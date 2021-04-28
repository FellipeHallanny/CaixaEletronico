using System;
using System.Linq;
using System.Threading.Tasks;
using CaixaEletronico.Application.Contratos;
using CaixaEletronico.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaixaEletronico.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotaController : ControllerBase
    {
        private readonly INotaService _notaService;

        public NotaController(INotaService notaService)
        {
            _notaService = notaService;
        }
        

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var notas = await _notaService.GetAllNotasAsync(true);
                if (notas == null) return NotFound("Nenhuma nota encontradas!");

                return Ok(notas);
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                    $"Erro ao tentar recuperar notas. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var nota = await _notaService.GetAllNotaByIdAsync(id,true);
                if (nota == null) return NotFound("Nota por Id não encontrada!");

                return Ok(nota);
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                    $"Erro ao tentar recuperar nota. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Nota model)
        {
            try
            {
                var nota = await _notaService.AddNotas(model);
                if (nota == null) return BadRequest("Erro ao tentar adicionar nota.");

                return Ok(nota);
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                    $"Erro ao tentar adicionar nota. Erro: {ex.Message}");
            }
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Nota model)
        {
            try
            {
                var nota = await _notaService.UpdateNotas(id,model);
                if (nota == null) return BadRequest("Erro ao tentar adicionar nota.");

                return Ok(nota);
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                    $"Erro ao tentar atualizar nota. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
               return await _notaService.DeleteNotas(id) ?
                   Ok("Deletado") :               
                   BadRequest("nota não deletado!");

            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                    $"Erro ao tentar deletar nota. Erro: {ex.Message}");
            }
        }
    }
}
