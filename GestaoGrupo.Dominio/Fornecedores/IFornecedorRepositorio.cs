using GestaoProduto.Dominio._Base;

namespace GestaoProduto.Dominio.Fornecedores
{
    public interface IFornecedorRepositorio : IRepositorio<Fornecedor>
    {        
        Fornecedor ObterPeloCNPJ(string cnpj);
        bool ContemDuplicidadeCNPJ(string cnpj);
        bool ExisteCNPJ(string cnpj);
    }
}