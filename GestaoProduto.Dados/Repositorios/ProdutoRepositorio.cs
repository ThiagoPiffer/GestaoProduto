using GestaoProduto.Dados.Contextos;
using GestaoProduto.Dominio.Produtos;

namespace GestaoProduto.Dados.Repositorios
{
    public class ProdutoRepositorio : RepositorioBase<Produto>, IProdutoRepositorio
    {
        public ProdutoRepositorio(ApplicationDbContext context) : base(context)
        {

        }

        public bool ContemDuplicidadeDescricao(ProdutoDto produtoDto)
        {
            var quantidade = Context.Set<Produto>().Where(a => a.Ativo && a.Descricao == produtoDto.Descricao && a.Id != produtoDto.Id).Count();
            return quantidade > 0 ? true : false;
        }

        public List<Produto> BuscaPorTermo(string termo)
        {
            var produtos = Context.Set<Produto>().Where(a => a.Ativo && a.Descricao.Contains(termo)).ToList();
            return produtos;
        }
    }
}

