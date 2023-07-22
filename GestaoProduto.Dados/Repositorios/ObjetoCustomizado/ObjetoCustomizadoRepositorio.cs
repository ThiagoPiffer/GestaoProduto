using GestaoProduto.Dados.Contextos;
using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity;
using GestaoProduto.Dominio.Repositorio;

namespace GestaoProduto.Dados.Repositorios
{
    public class ObjetoCustomizadoRepositorio : RepositorioBase<ObjetoCustomizado>, IObjetoCustomizadoRepositorio
    {
        public ObjetoCustomizadoRepositorio(ApplicationDbContext context) : base(context)
        {

        }

        public List<ObjetoCustomizado> BuscaPorTermo(string termo)
        {
            var obj = Context.Set<ObjetoCustomizado>().Where(a => a.Ativo && a.Descricao.Contains(termo)).ToList();
            return obj;
        }

        public void Armazenar(ObjetoCustomizadoDTO objetoCustomizadoDto)
        {
            var obj = Context.Set<ObjetoCustomizado>().Where(o => o.Id == objetoCustomizadoDto.Id).First();
            Context.Add(obj);
        }
    }
}
