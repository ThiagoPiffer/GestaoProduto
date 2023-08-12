using GestaoProduto.Dados.Contextos;
using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity;
using GestaoProduto.Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace GestaoProduto.Dados.Repositorios
{
    public class GrupoProcessoRepositorio : RepositorioBase<GrupoProcesso>, IGrupoProcessoRepositorio
    {
        public GrupoProcessoRepositorio(ApplicationDbContext context) : base(context)
        {

        }

        public async Task Armazenar(GrupoProcesso grupoProcesso)
        {
            await Context.GrupoProcessos.AddAsync(grupoProcesso);
        }

        public Task<List<GrupoProcesso>> ObterListaAsync()
        {
            return Context.GrupoProcessos.ToListAsync();
        }
    }
}
