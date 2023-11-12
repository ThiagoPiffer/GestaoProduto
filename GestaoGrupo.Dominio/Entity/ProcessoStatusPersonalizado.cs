using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._Empresa;

namespace GestaoProduto.Dominio.Entity._ProcessoStatusPersonalizado
{
    public class ProcessoStatusPersonalizado : Entidade
    {
        public ProcessoStatusPersonalizado() { }

        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public string? MensagemNotificacao { get; set; }
        public bool ValidaCondicao { get; set; }
        public bool MaiorQue { get; set; }
        public bool MenorQue { get; set; }
        public bool IgualA { get; set; }
        public int? ValorControle { get; set; }
        public string Cor { get; set; }
        public string Icone { get; set; } 
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
    }
}


