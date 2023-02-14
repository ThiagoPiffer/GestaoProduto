using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Fornecedores;

namespace GestaoProduto.Dominio.Produtos
{
    public interface IProdutoRepositorio : IRepositorio<Produto>
    {        
        bool ContemDuplicidadeDescricao(ProdutoDto produtoDto);

        List<Produto> BuscaPorTermo(string busca);
    }
}
