using GestaoProduto.Dominio.Entity._ArquivoProcessoTemplate;
using GestaoProduto.Dominio.Entity._TipoPessoaTemplate;
using GestaoProduto.Dominio.Model._ArquivoProcessoTemplate;
using GestaoProduto.Dominio.Model._TipoPessoaTemplate;
using Microsoft.AspNetCore.Http;

namespace GestaoProduto.Dominio.IServico._ArquivoProcessoTemplate
{
    public interface IArquivoProcessoTemplateServico
    {
        Task<List<ArquivoProcessoTemplate>> Listar();
        Task<ArquivoProcessoTemplate> ObterPorId(int id);
        Task<List<ArquivoProcessoTemplate>> BuscaPorTermo(string termo);
        Task<ArquivoProcessoTemplate> Adicionar(int idProcesso, int idEmpresa, IFormFile file);        
        Task<ArquivoProcessoTemplate> Editar(ArquivoProcessoTemplateModel arquivoprocessotemplateModel);
        Task<string> Delete(int id);        

    }
}
