using GestaoProduto.Dominio.Entity._TipoPessoaTemplate;
using GestaoProduto.Dominio.Model._PessoasProcesso;
using GestaoProduto.Dominio.Model._TipoPessoaTemplate;
using GestaoProduto.Dominio.Model.RequestModel;

namespace GestaoProduto.Dominio.IServico._TipoPessoaTemplateServico
{
    public interface ITipoPessoaTemplateServico
    {
        Task<List<TipoPessoaTemplate>> Listar();
        Task<TipoPessoaTemplateModel> ObterPorId(int id);
        Task<TipoPessoaTemplate> Adicionar(TipoPessoaTemplateModel tipoPessoaTemplateModel);
        Task<TipoPessoaTemplate> Editar(TipoPessoaTemplateModel tipoPessoaTemplateModel);
        Task<string> Delete(int id);
        Task<List<TipoPessoaTemplate>> AdicionarTipoPessoaTemplate(List<TipoPessoaTemplateModel> model);
        Task<List<PessoasProcessoModel>> ListarPessoaTemplate(int idArquivoTemplate, int idProcesso);
        List<TipoPessoaTemplateModel> ListarTiposPessoaTemplate(int idProccessoTemplate);
    }
}
