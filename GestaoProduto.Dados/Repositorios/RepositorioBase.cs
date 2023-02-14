using System.Collections.Generic;
using System.Linq;
using GestaoProduto.Dados.Contextos;
using GestaoProduto.Dominio._Base;

namespace GestaoProduto.Dados.Repositorios
{
    public class RepositorioBase<TEntidade> : IRepositorio<TEntidade> where TEntidade : Entidade
    {
        protected readonly ApplicationDbContext Context;

        public RepositorioBase(ApplicationDbContext context)
        {
            Context = context;
        }

        public void Adicionar(TEntidade entity)
        {
            Context.Set<TEntidade>().Add(entity);

        }

        public virtual TEntidade ObterPorId(int id)
        {
            var query = Context.Set<TEntidade>().Where(entidade => entidade.Id == id);
            return query.Any() ? query.First() : null;
        }

        public virtual List<TEntidade> Consultar()
        {
            var entidades = Context.Set<TEntidade>().ToList().Where(l => l.Ativo).ToList();
            return entidades.Any() ? entidades : new List<TEntidade>();
        }
    }
}
