
using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._ArquivoProcessoTemplate;

namespace GestaoProduto.Dominio.IRepositorio._ArquivoProcessoTemplate
{    
    public interface IArquivoProcessoTemplateRepositorio : IRepositorio<ArquivoProcessoTemplate>
    {
        Task<List<ArquivoProcessoTemplate>> BuscaPorTermo(string termo);
        Task Armazenar(ArquivoProcessoTemplate arquivoprocessotemplate);
        void Update(ArquivoProcessoTemplate arquivoprocessotemplate);
    }
}
