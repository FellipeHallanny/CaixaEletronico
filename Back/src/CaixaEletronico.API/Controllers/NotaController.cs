using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaixaEletronico.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CaixaEletronico.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotaController : ControllerBase
    {
        
        public IEnumerable<Nota> _notas = new Nota[] {
            new Nota(){
                    NotaId = 1,
                    Valor = 50,
                    QtdNota = 100,
                    QrtCriticaNota = 15,
                    ImagemURl = "nota50.png"

             },
              new Nota(){
                    NotaId = 2,
                    Valor = 20,
                    QtdNota = 100,
                    QrtCriticaNota = 15,
                    ImagemURl = "nota20.png"

             }
        };

        private readonly ILogger<NotaController> _logger;

        public NotaController(ILogger<NotaController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Nota> GetNotas()
        {
           return _notas;
    
           
        }

        [HttpGet("{id}")]
        public IEnumerable<Nota> GetNotasById(int id)
        {
          return _notas.Where(n => n.NotaId == id);
        }
    }
}
