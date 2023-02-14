using GestaoProduto.Dominio._Base;

namespace GestaoProduto.Dominio.Fornecedores
{
    public interface IFornecedorRepositorio : IRepositorio<Fornecedor>
    {        
        Fornecedor ObterPeloCNPJ(string cnpj);
        bool ContemDuplicidadeCNPJ(FornecedorDto fornecedorDto);
        bool ExisteCNPJ(string cnpj);
    }
}