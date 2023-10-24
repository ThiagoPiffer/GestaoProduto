using GestaoProduto.Dominio._Base;

namespace GestaoProduto.Dominio.Entity._ArquivoProcessoTemplate
{
    public class ArquivoProcessoTemplate : Entidade
    {
        public ArquivoProcessoTemplate() { }

        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public string CaminhoArquivo { get; set; }
        public long TamanhoArquivo { get; set; }
        public int idEmpresa { get; set; }
    }
}
