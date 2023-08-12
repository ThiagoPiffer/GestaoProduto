using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity;
using GestaoProduto.Dominio.Model;

namespace GestaoProduto.Dominio.Repositorio
{    
    public interface IProcessoRepositorio : IRepositorio<Processo>
    {
        Task<List<Processo>> BuscaPorTermo(string termo);
        Task Armazenar(Processo processo);  
        void Update(Processo processo);
        Task<List<GrupoProcessoModel>> ListarGrupoProcessoModel();
    }
}
