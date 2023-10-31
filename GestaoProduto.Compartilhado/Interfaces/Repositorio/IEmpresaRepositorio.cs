
using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._Empresa;

namespace GestaoProduto.Compartilhado.Interfaces.Repositorio._Empresa
{    
    public interface IEmpresaRepositorio : IRepositorio<Empresa>
    {
        Task<List<Empresa>> BuscaPorTermo(string termo);
        Task Armazenar(Empresa empresa);
        void Update(Empresa empresa);
        Task<Empresa> ObterEmpresaUsuarioIdentity(string id);
    }
}
