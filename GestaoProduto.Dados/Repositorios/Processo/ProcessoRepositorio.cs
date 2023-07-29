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
            Context.Add(processo);
        }

        public void Update(Processo processo)
        {
            Context.Update(processo);
        }

        public void Delete(int id) 
        {
            var processo = this.ObterPorId(id);
            Context.Remove(processo);
        }

    }
}
