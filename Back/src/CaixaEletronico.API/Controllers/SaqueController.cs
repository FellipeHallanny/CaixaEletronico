using CaixaEletronico.Application.Contratos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaixaEletronico.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaqueController : ControllerBase
    {
        private readonly ISaqueService _saqueService;

        public SaqueController(ISaqueService saqueService)
        {
            _saqueService = saqueService;
        }

        [HttpPut]
        public async Task<IActionResult> Sacar(int caixaId, int valor)
        {
            try
            {
                var caixa = _saqueService.Saque(caixaId, valor);
                if (caixa == null) return BadRequest("Erro ao tentar desativar caixa.Verifique o ID");

                return Ok(caixa);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                    $"Erro ao tentar atualizar caixa. Erro: {ex.Message}");
            }
        }
    }
}
