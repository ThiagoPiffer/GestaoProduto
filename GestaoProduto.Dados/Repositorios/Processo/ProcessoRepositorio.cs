using GestaoProduto.Dados.Contextos;
using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity;
using GestaoProduto.Dominio.Repositorio;

namespace GestaoProduto.Dados.Repositorios
{    
    public class ProcessoRepositorio : RepositorioBase<Processo>, IProcessoRepositorio
    {
        public ProcessoRepositorio(ApplicationDbContext context) : base(context)
        {

        }

        public List<Processo> BuscaPorTermo(string termo)
        {
            var obj = Context.Set<Processo>().Where(a => a.Ativo && a.Descricao.Contains(termo)).ToList();
            return obj;
        }

        public void Armazenar(Processo processo)
        {
            var obj = Context.Set<Processo>().Where(o => o.Id == processo.Id).First();
            Context.Add(obj);
        }

    }
}
