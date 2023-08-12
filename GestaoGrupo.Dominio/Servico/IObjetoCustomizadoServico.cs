using GestaoProduto.Dominio.Entity;

namespace GestaoProduto.Dominio.Servico
{
    public interface IObjetoCustomizadoServico
    {
        Task<List<ObjetoCustomizadoDTO>> Get();
        Task<ObjetoCustomizadoDTO> Get(int id);
        Task<List<ObjetoCustomizadoDTO>> BuscaPorTermo(string termo);
        Task<string> Add(ObjetoCustomizadoDTO produtoDto);
        Task<ObjetoCustomizadoDTO> Update(ObjetoCustomizadoDTO produtoDto, int id);
        Task<string> Delete(int id);
    }
}
