using System.Collections.Generic;

namespace GestaoProduto.Dominio._Base
{
    public interface IRepositorio<TEntidade>
    {
        Task<TEntidade> ObterPorIdAsync(int id);
        Task<List<TEntidade>> ObterListaAsync();
        Task<TEntidade> AdicionarAsync(TEntidade entity);
        Task<TEntidade> EditarAsync(TEntidade entity);
        Task ExcluirAsync(TEntidade entity);

    }
}
