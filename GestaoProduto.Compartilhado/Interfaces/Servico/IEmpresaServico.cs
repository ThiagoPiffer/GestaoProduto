using GestaoProduto.Compartilhado.Model._Empresa;
using GestaoProduto.Dominio.Entity._Empresa;

namespace GestaoProduto.Compartilhado.Interfaces.Servico._Empresa
{
    public interface IEmpresaServico
    {
        Task<List<Empresa>> Listar();
        Task<EmpresaModel> ObterPorId(int id);
        Task<Empresa> ObterEmpresaUsuarioIdentity(string id);

        Task<List<Empresa>> BuscaPorTermo(string termo);
        Task<Empresa> Adicionar(EmpresaModel empresaModel);
        Task<Empresa> Editar(EmpresaModel empresaModel);
        Task<string> Delete(int id);
    }
}
