using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity;
using GestaoProduto.Dominio.Model;

namespace GestaoProduto.Dominio.Repositorio
{
    public interface IArquivoProcessoRepositorio : IRepositorio<ArquivoProcesso>
    {
        Task<List<ArquivoProcesso>> ListarArquivosProcesso(int idProcesso);

    }
}
