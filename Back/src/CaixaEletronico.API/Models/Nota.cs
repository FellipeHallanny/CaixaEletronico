namespace CaixaEletronico.API.Models
{
    public class Nota
    {
        public int NotaId { get; set; }
        public int Valor { get; set; }
        public int QtdNota { get; set; }
        public int QrtCriticaNota { get; set; }
        public string ImagemURl { get; set; }
    }
}