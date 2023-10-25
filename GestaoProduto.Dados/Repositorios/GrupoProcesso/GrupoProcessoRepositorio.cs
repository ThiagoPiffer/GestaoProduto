using GestaoProduto.Dados.Contextos;
using GestaoProduto.Dados.Repositorio._RepositorioBase;
using GestaoProduto.Dominio.Entity._GrupoProcesso;
using GestaoProduto.Dominio.IRepositorio._GrupoProcesso;
using Microsoft.EntityFrameworkCore;

namespace GestaoProduto.Dados.Repositorio._GrupoProcesso
{
    public class GrupoProcessoRepositorio : RepositorioBase<GrupoProcesso>, IGrupoProcessoRepositorio
    {
        public GrupoProcessoRepositorio(ApplicationDbContext context) : base(context)
        {

        }

        public async Task Armazenar(GrupoProcesso grupoProcesso)
        {
            await Context.GrupoProcesso.AddAsync(grupoProcesso);
        }

        public Task<List<GrupoProcesso>> ObterListaCustomizadaAsync()
        {
            return Context.GrupoProcesso.ToListAsync();
        }
    }
}
