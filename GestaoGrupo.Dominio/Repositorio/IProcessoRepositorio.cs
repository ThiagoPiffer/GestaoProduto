using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity;

namespace GestaoProduto.Dominio.Repositorio
{    
    public interface IProcessoRepositorio : IRepositorio<Processo>
    {
        List<Processo> BuscaPorTermo(string termo);
        void Armazenar(Processo processo);
    }
}
