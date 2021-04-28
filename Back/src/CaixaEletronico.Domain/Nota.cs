using System.Collections.Generic;

namespace CaixaEletronico.Domain
{
    public class Nota
    {
        public int Id { get; set; }
        public int Valor { get; set; }
        public int QtdNota { get; set; }
        public int QrtCriticaNota { get; set; }
        public string ImagemURl { get; set; }
        public IEnumerable<CaixaNota> CaixaNotas { get; set; }
    }
}