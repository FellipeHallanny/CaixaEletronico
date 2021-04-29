using System;
using System.Threading.Tasks;
using CaixaEletronico.Application.Contratos;
using CaixaEletronico.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaixaEletronico.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CaixaController : ControllerBase
    {
        private readonly ICaixaService _caixaService;
        public CaixaController(ICaixaService caixaService)
        {
            _caixaService = caixaService;

        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var caixas = await _caixaService.GetAllCaixasAsync(true);
                if (caixas == null) return NotFound("Nenhuma nota encontradas!");

                return Ok(caixas);
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                    $"Erro ao tentar recuperar caixas. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var caixa = await _caixaService.GetAllCaixaByIdAsync(id,true);
                if (caixa == null) return NotFound("caixa por Id não encontrada!");

                return Ok(caixa);
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                    $"Erro ao tentar recuperar caixa. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Caixa model)
        {
            try
            {
                var caixa = await _caixaService.AddCaixas(model);
                if (caixa == null) return BadRequest("Erro ao tentar adicionar caixa.");

                return Ok(caixa);
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                    $"Erro ao tentar adicionar caixa. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Caixa model)
        {
            try
            {
                var caixa = await _caixaService.UpdateCaixas(id,model);
                if (caixa == null) return BadRequest("Erro ao tentar adicionar caixa.");

                return Ok(caixa);
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                    $"Erro ao tentar atualizar caixa. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
               return await _caixaService.DeleteCaixas(id) ?
                   Ok("Deletado") :               
                   BadRequest("caixa não deletado!");

            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                    $"Erro ao tentar deletar caixa. Erro: {ex.Message}");
            }
        }
    }
}