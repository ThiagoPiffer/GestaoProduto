using System.Collections.Generic;

namespace GestaoProduto.Dominio._Base
{
    public interface IRepositorio<TEntidade>
    {
        TEntidade ObterPorId(int id);
        List<TEntidade> ObterLista();
        void Adicionar(TEntidade entity);
    }
}
