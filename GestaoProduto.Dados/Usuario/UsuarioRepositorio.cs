
using GestaoProduto.Dados.Contextos;
using GestaoProduto.Dados.Repositorio._RepositorioBase;
using GestaoProduto.Dominio.Entity._Usuario;
using GestaoProduto.Dominio.IRepositorio._Usuario;
using Microsoft.EntityFrameworkCore;

namespace GestaoProduto.Dados.Repositorio._Usuario
{
    public class UsuarioRepositorio : RepositorioBase<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(ApplicationDbContext context) : base(context)
        {

        }

        public Task<List<Usuario>> BuscaPorTermo(string termo)
        {
            var obj = Context.Set<Usuario>().Where(a => a.Ativo && a.Nome != null && a.Nome.Contains(termo)).ToListAsync();
            return obj;
        }

        public async Task Armazenar(Usuario usuario)
        {
            try
            {
                await Context.AddAsync(usuario);
                await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null) ex = ex.InnerException;
                Console.WriteLine(ex.Message);
            }

        }

        public void Update(Usuario usuario)
        {
            Context.Update(usuario);
        }
    }
}
