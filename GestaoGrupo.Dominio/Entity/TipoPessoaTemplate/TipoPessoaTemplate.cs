using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._ArquivoProcessoTemplate;
using GestaoProduto.Dominio.Entity._TipoPessoa;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoProduto.Dominio.Entity._TipoPessoaTemplate
{
    public class TipoPessoaTemplate: Entidade
    {
        public TipoPessoaTemplate() { }

        public int IdTipoPessoa { get; set; }

        //[ForeignKey("TipoPessoa")]
        //public int IdTipoPessoa { get; set; }

        //public virtual TipoPessoa TipoPessoa { get; set; }

        public int IdArquivoProcessoTemplate { get; set; }
        public string CampoChave { get; set; }
    }
}
