using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._ArquivoProcessoTemplate;
using GestaoProduto.Dominio.Entity._TipoPessoa;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoProduto.Dominio.Entity._TipoPessoaTemplate
{
    public class TipoPessoaTemplate: Entidade
    {
        public TipoPessoaTemplate() { }

        public int TipoPessoaId { get; set; }
        public TipoPessoa TipoPessoa { get; set; }

        public int ArquivoProcessoTemplateId { get; set; }
        public ArquivoProcessoTemplate ArquivoProcessoTemplate { get; set; }
        public string CampoChave { get; set; }
    }
}
