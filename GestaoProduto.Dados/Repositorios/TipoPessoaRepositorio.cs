using GestaoProduto.Dados.Contextos;
using GestaoProduto.Dados.Repositorio._RepositorioBase;
using GestaoProduto.Dominio.Entity._TipoPessoa;
using GestaoProduto.Dominio.Entity._Usuario;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._TipoPessoa;
using Microsoft.EntityFrameworkCore;

namespace GestaoProduto.Dados.Repositorio._TipoPessoa
{
    public class TipoPessoaRepositorio : RepositorioBase<TipoPessoa>, ITipoPessoaRepositorio
    {
        public TipoPessoaRepositorio(ApplicationDbContext context) : base(context)
        {

        }

        public Task<List<TipoPessoa>> BuscaPorTermo(string termo)
        {
            var obj = Context.Set<TipoPessoa>().Where(a => a.Ativo && a.Descricao != null && a.Descricao.Contains(termo)).ToListAsync();
            return obj;
        }

        public async Task<TipoPessoa> BurcaPorId(int id)
        {
            var obj = await Context.Set<TipoPessoa>().FirstOrDefaultAsync(a => a.Ativo && a.Id == id);
            return obj;
        }


        public async Task Armazenar(TipoPessoa tipoPessoa)
        {
            try
            {
                await Context.AddAsync(tipoPessoa);
                await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null) ex = ex.InnerException;
                Console.WriteLine(ex.Message);
            }

        }

        public void Update(TipoPessoa tipoPessoa)
        {
            Context.Update(tipoPessoa);
        }
    }
}