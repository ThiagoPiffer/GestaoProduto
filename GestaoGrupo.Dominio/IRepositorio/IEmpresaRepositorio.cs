
using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._Empresa;

namespace GestaoProduto.Dominio.IRepositorio._Empresa
{    
    public interface IEmpresaRepositorio : IRepositorio<Empresa>
    {
        Task<List<Empresa>> BuscaPorTermo(string termo);
        Task Armazenar(Empresa empresa);
        void Update(Empresa empresa);
    }
}
