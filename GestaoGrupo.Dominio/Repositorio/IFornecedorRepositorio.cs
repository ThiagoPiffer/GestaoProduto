using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity;

namespace GestaoProduto.Dominio.Repositorio
{
    public interface IFornecedorRepositorio : IRepositorio<Fornecedor>
    {
        Fornecedor ObterPeloCNPJ(string cnpj);
        bool ContemDuplicidadeCNPJ(FornecedorDto fornecedorDto);
        bool ExisteCNPJ(string cnpj);
    }
}