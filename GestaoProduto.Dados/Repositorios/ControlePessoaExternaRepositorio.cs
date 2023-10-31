using GestaoProduto.Dados.Contextos;
using GestaoProduto.Dados.Repositorio._RepositorioBase;
using GestaoProduto.Dominio.Entity._ControlePessoaExterna;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._ControlePessoaExterna;

namespace GestaoProduto.Dados.Repositorio._ControlePessoaExterna
{
    public class ControlePessoaExternaRepositorio : RepositorioBase<ControlePessoaExterna>, IControlePessoaExternaRepositorio
    {
        public ControlePessoaExternaRepositorio(ApplicationDbContext context) : base(context)
        {

        }

    }
}