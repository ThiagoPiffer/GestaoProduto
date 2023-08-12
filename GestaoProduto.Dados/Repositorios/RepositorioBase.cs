using System.Collections.Generic;
using System.Linq;
using GestaoProduto.Dados.Contextos;
using GestaoProduto.Dominio._Base;
using Microsoft.EntityFrameworkCore;

namespace GestaoProduto.Dados.Repositorios
{
    //public class RepositorioBase<TEntidade> : IRepositorio<TEntidade> where TEntidade : Entidade
    //{
    //    protected readonly ApplicationDbContext Context;

    //    public RepositorioBase(ApplicationDbContext context)
    //    {
    //        Context = context;
    //    }

    //    public void Adicionar(TEntidade entity)
    //    {
    //        Context.Set<TEntidade>().Add(entity);

    //    }

    //    public virtual TEntidade ObterPorId(int id)
    //    {
    //        var query = Context.Set<TEntidade>().Where(entidade => entidade.Id == id);
    //        return query.Any() ? query.First() : null;
    //    }

    //    public virtual List<TEntidade> ObterLista()
    //    {
    //        var entidades = Context.Set<TEntidade>().ToList().Where(l => l.Ativo).ToList();
    //        return entidades.Any() ? entidades : new List<TEntidade>();
    //    }
    //}

    public class RepositorioBase<TEntidade> : IRepositorio<TEntidade> where TEntidade : Entidade
    {
        protected readonly ApplicationDbContext Context;

        public RepositorioBase(ApplicationDbContext context)
        {
            Context = context;
        }

        public virtual async Task<TEntidade> AdicionarAsync(TEntidade entity)
        {
            await Context.Set<TEntidade>().AddAsync(entity);            
            return entity;
        }

        public virtual async Task<TEntidade> EditarAsync(TEntidade entity)
        {
            Context.Set<TEntidade>().Update(entity);
            await Context.SaveChangesAsync();
            return entity;
        }


        public virtual async Task<TEntidade> ObterPorIdAsync(int id)
        {
            var entidade = await Context.Set<TEntidade>().FirstOrDefaultAsync(entidade => entidade.Id == id);
            if (entidade == null)
            {
                throw new InvalidOperationException($"A entidade com o Id {id} não foi encontrada.");
            }
            return entidade;
        }


        public virtual async Task<List<TEntidade>> ObterListaAsync()
        {
            var entidades = await Context.Set<TEntidade>().Where(l => l.Ativo).ToListAsync();
            return entidades.Any() ? entidades : new List<TEntidade>();
        }

        public async Task ExcluirAsync(TEntidade entity)
        {
            Context.Set<TEntidade>().Remove(entity);
            await Context.SaveChangesAsync();
        }
    }

}
