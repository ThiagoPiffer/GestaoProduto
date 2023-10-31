using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._ArquivoProcesso;

namespace GestaoProduto.Compartilhado.Interfaces.Repositorio._ArquivoProcesso
{
    public interface IArquivoProcessoRepositorio : IRepositorio<ArquivoProcesso>
    {
        Task<List<ArquivoProcesso>> ListarArquivosProcesso(int idProcesso);

    }
}
