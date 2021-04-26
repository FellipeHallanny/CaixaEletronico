using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaixaEletronico.API.Data;
using CaixaEletronico.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CaixaEletronico.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotaController : ControllerBase
    {
        
        private readonly CaixaEletronicoContext _caixaEletronicoContext;

        public NotaController(CaixaEletronicoContext caixaEletronicoContext)
        {
            _caixaEletronicoContext = caixaEletronicoContext;

        }

        [HttpGet]
        public IEnumerable<Nota> GetNotas()
        {
            return _caixaEletronicoContext.Notas;
        }

        [HttpGet("{id}")]
        public Nota GetNotasById(int id)
        {
            return _caixaEletronicoContext.Notas.FirstOrDefault(n => n.NotaId == id);
        }
    }
}
