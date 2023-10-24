using GestaoProduto.Dados.Contextos;
using GestaoProduto.Dominio.Entity._ArquivoProcessoTemplate;
using GestaoProduto.Dominio.Model._ArquivoProcessoTemplate;
using GestaoProduto.Dominio.IRepositorio;
using GestaoProduto.Dominio.IRepositorio._ArquivoProcessoTemplate;
using Microsoft.EntityFrameworkCore;
using GestaoProduto.Dados.Repositorio._RepositorioBase;

namespace GestaoProduto.Dados.Repositorio._ArquivoProcessoTemplateRepositorio
{
    public class ArquivoProcessoTemplateRepositorio : RepositorioBase<ArquivoProcessoTemplate>, IArquivoProcessoTemplateRepositorio                                                                                                
    {
        public ArquivoProcessoTemplateRepositorio(ApplicationDbContext context) : base(context)
        {

        }

        public Task<List<ArquivoProcessoTemplate>> BuscaPorTermo(string termo)
        {
            var obj = Context.Set<ArquivoProcessoTemplate>().Where(a => a.Ativo && a.Descricao != null && a.Descricao.Contains(termo)).ToListAsync();
            return obj;
        }

        public async Task Armazenar(ArquivoProcessoTemplate arquivoprocessotemplate)
        {
            try
            {
                await Context.AddAsync(arquivoprocessotemplate);
                await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null) ex = ex.InnerException;
                Console.WriteLine(ex.Message);
            }

        }

        public void Update(ArquivoProcessoTemplate arquivoprocessotemplate)
        {
            Context.Update(arquivoprocessotemplate);
        }
    }
}
