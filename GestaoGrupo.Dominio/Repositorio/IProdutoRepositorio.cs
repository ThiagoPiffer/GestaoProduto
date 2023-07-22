using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity;

namespace GestaoProduto.Dominio.Repositorio
{
    public interface IProdutoRepositorio : IRepositorio<Produto>
    {
        bool ContemDuplicidadeDescricao(ProdutoDto produtoDto);

        List<Produto> BuscaPorTermo(string busca);
    }
}
