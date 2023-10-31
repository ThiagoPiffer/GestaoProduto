using GestaoProduto.Dominio.Entity._ArquivoProcessoTemplate;
using GestaoProduto.Dominio.Entity._TipoPessoaTemplate;
using GestaoProduto.Compartilhado.Model._ArquivoProcessoTemplate;
using GestaoProduto.Dominio.Model._TipoPessoaTemplate;
using Microsoft.AspNetCore.Http;

namespace GestaoProduto.Compartilhado.Interfaces.Servico._ArquivoProcessoTemplate
{
    public interface IArquivoProcessoTemplateServico
    {
        Task<List<ArquivoProcessoTemplate>> Listar();
        Task<ArquivoProcessoTemplate> ObterPorId(int id);
        Task<List<ArquivoProcessoTemplate>> BuscaPorTermo(string termo);
        Task<ArquivoProcessoTemplate> Adicionar(int idProcesso, IFormFile file, List<TipoPessoaTemplateModel> tiposPessoaTemplate);
        Task<ArquivoProcessoTemplate> Editar(ArquivoProcessoTemplateModel arquivoprocessotemplateModel);
        Task<string> Delete(int id);        

    }
}
