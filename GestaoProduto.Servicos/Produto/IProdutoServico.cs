using GestaoProduto.Dominio.Entity;

namespace GestaoProduto.Servico
{
    public interface IProdutoServico
    {
        Task<List<ProdutoDto>> Get();
        Task<ProdutoDto> Get(int id);
        Task<List<ProdutoDto>> BuscaPorTermo(string termo);
        Task<string> Add(ProdutoDto produtoDto);
        Task<ProdutoDto> Update(ProdutoDto produtoDto, int id);
        Task<string> Delete(int id);
    }
}