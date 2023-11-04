using GestaoProduto.Compartilhado.Model._Empresa;

namespace GestaoProduto.Compartilhado.Model._ProcessoStatusPersonalizado
{
    public class ProcessoStatusPersonalizadoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; } = string.Empty;
        public string? MensagemNotificacao { get; set; } = string.Empty;
        public bool ValidaCondicao { get; set; }
        public bool MaiorQue { get; set; }
        public bool MenorQue { get; set; }
        public bool IgualA { get; set; }
        public DateTime? DataControle { get; set; }
        public string Cor { get; set; } = string.Empty;
        public int EmpresaId { get; set; }
        public EmpresaModel Empresa { get; set; } = null!;
    }
}


