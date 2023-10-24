using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._ArquivoProcesso;

namespace GestaoProduto.Dominio.IRepositorio._ArquivoProcesso
{
    public interface IArquivoProcessoRepositorio : IRepositorio<ArquivoProcesso>
    {
        Task<List<ArquivoProcesso>> ListarArquivosProcesso(int idProcesso);

    }
}
