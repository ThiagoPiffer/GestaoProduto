using GestaoProduto.Dominio.Entity;

namespace GestaoProduto.Dominio.Servico
{
    public interface IFornecedorServico
    {
        Task<List<FornecedorDto>> Get();
        Task<FornecedorDto> Get(int id);
        Task<FornecedorDto> Add(FornecedorDto fornecedorDto);
        Task<FornecedorDto> Update(FornecedorDto fornecedorDto, int id);
        Task<string> Delete(int id);

    }

}