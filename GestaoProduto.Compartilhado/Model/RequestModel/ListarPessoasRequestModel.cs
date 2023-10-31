using GestaoProduto.Dominio.Model._TipoPessoaTemplate;

namespace GestaoProduto.Compartilhado.Model.RequestModel
{
    public class ListarPessoasRequestModel
    {
        public int IdProcesso { get; set; }
        public List<TipoPessoaTemplateModel> TiposPessoaTemplate { get; set; }
    }
}
