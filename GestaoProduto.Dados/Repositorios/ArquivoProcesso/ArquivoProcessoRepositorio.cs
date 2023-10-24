using GestaoProduto.Dados.Contextos;
using GestaoProduto.Dominio.Entity._ArquivoProcesso;
using GestaoProduto.Dominio.IRepositorio._ArquivoProcesso;
using Microsoft.EntityFrameworkCore;
using GestaoProduto.Dados.Repositorio._RepositorioBase;

namespace GestaoProduto.Dados.Repositorio._ArquivoProcesso
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
