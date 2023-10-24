
using GestaoProduto.Dados.Contextos;
using GestaoProduto.Dados.Repositorio._RepositorioBase;
using GestaoProduto.Dominio.Entity._Empresa;
using GestaoProduto.Dominio.IRepositorio._Empresa;
using Microsoft.EntityFrameworkCore;

namespace GestaoProduto.Dados.Repositorio._Empresa
{
    public class EmpresaRepositorio : RepositorioBase<Empresa>, IEmpresaRepositorio
    {
        public EmpresaRepositorio(ApplicationDbContext context) : base(context)
        {

        }

        public Task<List<Empresa>> BuscaPorTermo(string termo)
        {
            var obj = Context.Set<Empresa>().Where(a => a.Ativo && a.Nome != null && a.Nome.Contains(termo)).ToListAsync();
            return obj;
        }

        public async Task Armazenar(Empresa empresa)
        {
            try
            {
                await Context.AddAsync(empresa);
                await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null) ex = ex.InnerException;
                Console.WriteLine(ex.Message);
            }

        }

        public void Update(Empresa empresa)
        {
            Context.Update(empresa);
        }
    }
}
