using GestaoProduto.Dados.Contextos;
using GestaoProduto.Dominio.Entity;
using GestaoProduto.Dominio.Model;
using GestaoProduto.Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace GestaoProduto.Dados.Repositorios
{
    public class ArquivoProcessoRepositorio : RepositorioBase<ArquivoProcesso>, IArquivoProcessoRepositorio
    {
        public ArquivoProcessoRepositorio(ApplicationDbContext context) : base(context)
        { }

        public async Task<List<ArquivoProcesso>> ListarArquivosProcesso(int idProcesso)
        {
            return await Context.ArquivoProcesso.Where(a => a.ProcessoId == idProcesso).ToListAsync();
        }

    }
}
