using GestaoProduto.Dominio.Entity._Empresa;
using GestaoProduto.Dominio.Model._Empresa;

namespace GestaoProduto.Dominio.IServico._Empresa
{
    public interface IEmpresaServico
    {
        Task<List<Empresa>> Listar();
        Task<EmpresaModel> ObterPorId(int id);
        Task<List<Empresa>> BuscaPorTermo(string termo);
        Task<Empresa> Adicionar(EmpresaModel empresaModel);
        Task<Empresa> Editar(EmpresaModel empresaModel);
        Task<string> Delete(int id);
    }
}
