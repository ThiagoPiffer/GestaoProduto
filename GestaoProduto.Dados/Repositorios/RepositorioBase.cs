using System.Collections.Generic;
using System.Linq;
using GestaoProduto.Dados.Contextos;
using GestaoProduto.Dominio._Base;
using Microsoft.EntityFrameworkCore;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace GestaoProduto.Dados.Repositorios
{
    public class RepositorioBase<TEntidade> : IRepositorio<TEntidade> where TEntidade : Entidade
    {
        protected readonly ApplicationDbContext Context;

        public RepositorioBase(ApplicationDbContext context)
        {
            Context = context;
        }

        public virtual async Task<TEntidade> AdicionarAsync(TEntidade entity)
        {
            try
            {
                entity.DataCadastro = DateTime.Now;
                entity.Ativo = true;

                await Context.Set<TEntidade>().AddAsync(entity);
                await Context.SaveChangesAsync();

                return entity;
            }catch (Exception ex)
            {
                var x  = ex.Message;
                return null;
            }
        }

        public virtual async Task<TEntidade> AdicionarAsyncSaveChanges(TEntidade entity)
        {
            entity.DataCadastro = DateTime.Now;
            entity.Ativo = true;

            await Context.Set<TEntidade>().AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }


        public virtual async Task<TEntidade> EditarAsync(TEntidade entity)
        {
            try
            {
                Context.Set<TEntidade>().Update(entity);
                await Context.SaveChangesAsync();
                return entity;
            }catch (Exception ex)
            {
                var x = ex.Message;
                return null;
            }
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
