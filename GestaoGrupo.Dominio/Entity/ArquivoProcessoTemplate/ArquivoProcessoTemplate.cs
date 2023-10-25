using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._Empresa;

namespace GestaoProduto.Dominio.Entity._ArquivoProcessoTemplate
{
    public class ArquivoProcessoTemplate : Entidade
    {
        public ArquivoProcessoTemplate() { }

        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public string CaminhoArquivo { get; set; }
        public long TamanhoArquivo { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
    }
}
