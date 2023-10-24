using GestaoProduto.Dominio.Model._TipoPessoaTemplate;

namespace GestaoProduto.Dominio.Model.RequestModel
{
    public class ListarPessoasRequestModel
    {
        public int IdProcesso { get; set; }
        public List<TipoPessoaTemplateModel> TiposPessoaTemplate { get; set; }
    }
}
