using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using GestaoProduto.Dados.Contextos;
using GestaoProduto.Dominio._Base;
using Microsoft.EntityFrameworkCore;
//using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace GestaoProduto.Dados.Repositorio._RepositorioBase
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

        public virtual async Task<List<TEntidade>> AdicionarListaAsync(List<TEntidade> entities)
        {
            try
            {
                // Define os valores padrão para todas as entidades
                foreach (var entity in entities)
                {
                    entity.DataCadastro = DateTime.Now;
                    entity.Ativo = true;
                }

                // Adiciona todas as entidades ao contexto do banco de dados
                await Context.Set<TEntidade>().AddRangeAsync(entities);

                // Salva as alterações no banco de dados
                await Context.SaveChangesAsync();

                return entities;
            }
            catch (Exception ex)
            {
                // Loga ou trata o erro aqui
                var errorMessage = ex.Message;
                // Você pode querer logar o erro ou fazer algo com ele
                // Por exemplo, você pode rethrow a exceção ou logá-la em algum sistema de monitoramento de erros
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

        public void DetachAllInstancesOfEntity(int entityId)
        {
            var local = Context.Set<TEntidade>().Local
                .FirstOrDefault(entry => entry.Id.Equals(entityId));
            if (local != null)
            {
                Context.Entry(local).State = EntityState.Detached;
            }
        }


        public async Task ExcluirAsync(TEntidade entity)
        {
            try
            {
                Context.Set<TEntidade>().Remove(entity);
                await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var x = ex.Message;
                
            }
        }

        public async Task<IEnumerable<TEntidade>> ObterListaFiltroAsync(Expression<Func<TEntidade, bool>> predicate)
        {
            return await Context.Set<TEntidade>().AsNoTracking().Where(predicate).ToListAsync();
        }
    }

}
