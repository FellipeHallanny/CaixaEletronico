using System.Collections.Generic;

namespace CaixaEletronico.Domain
{
    public class Caixa
    {
        public int Id { get; set; }
        public string DescricaoLocal { get; set; }
        public bool IsAtivo { get; set; }
        public IEnumerable<CaixaNota> CaixaNotas { get; set; }
    }
}