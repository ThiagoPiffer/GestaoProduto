using GestaoProduto.Dominio.Entity;
using GestaoProduto.Dominio.Entity._ArquivoProcesso;
using GestaoProduto.Compartilhado.Model._ArquivoProcesso;

namespace GestaoProduto.Compartilhado.Interfaces.Servico._ArquivoProcesso
{
    public interface IArquivoProcessoServico
    {
        Task<List<ArquivoProcessoModel>> Listar();
        Task<List<ArquivoProcessoModel>> ListarArquivosProcesso(int idProcesso);
        Task<ArquivoProcessoModel> ObterPorId(int id);
        Task<ArquivoProcesso> Adicionar(ArquivoProcessoModel pessoaModel, Stream fileStream);
        Task<ArquivoProcesso> Editar(ArquivoProcessoModel pessoaModel);
        Task<ArquivoProcesso> EditarDescricao(int id, string descricao);
        Task<string> Delete(int id);
    }
}
