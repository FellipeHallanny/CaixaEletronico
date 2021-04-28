namespace CaixaEletronico.Domain
{
    public class CaixaNota
    {
        public int CaixaId { get; set; }
        public Caixa Caixa { get; set; }
        public int NotaId { get; set; }
        public Nota Nota { get; set; }
    }
}