using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._Processo;
using GestaoProduto.Dominio.Model._GrupoProcesso;

namespace GestaoProduto.Dominio.IRepositorio._Processo
{    
    public interface IProcessoRepositorio : IRepositorio<Processo>
    {
        Task<List<Processo>> BuscaPorTermo(string termo);
        Task Armazenar(Processo processo);  
        void Update(Processo processo);
        Task<List<GrupoProcessoModel>> ListarGrupoProcessoModel();
    }
}
