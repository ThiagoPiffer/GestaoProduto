using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GestaoProduto.Dominio._Base
{
    public interface IRepositorio<TEntidade>
    {
        Task<TEntidade> ObterPorIdAsync(int id);
        Task<List<TEntidade>> ObterListaAsync();
        Task<TEntidade> AdicionarAsync(TEntidade entity);
        Task<List<TEntidade>> AdicionarListaAsync(List<TEntidade> entities);
        Task<TEntidade> AdicionarAsyncSaveChanges(TEntidade entity);
        Task<TEntidade> EditarAsync(TEntidade entity);
        Task ExcluirAsync(TEntidade entity);
        void DetachAllInstancesOfEntity(int entityId);
        Task<List<TEntidade>> ObterListaFiltroAsync(Expression<Func<TEntidade, bool>> predicate);


    }
}
