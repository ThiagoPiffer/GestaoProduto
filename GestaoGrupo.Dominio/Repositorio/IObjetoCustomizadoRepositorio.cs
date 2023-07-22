using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity;

namespace GestaoProduto.Dominio.Repositorio
{
    public interface IObjetoCustomizadoRepositorio : IRepositorio<ObjetoCustomizado>
    {
        List<ObjetoCustomizado> BuscaPorTermo(string termo);
        void Armazenar(ObjetoCustomizadoDTO objetoCustomizadoDto);
    }
}
