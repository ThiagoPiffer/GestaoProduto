using GestaoProduto.Dados.Contextos;
using GestaoProduto.Dados.Repositorio._RepositorioBase;
using GestaoProduto.Dominio.Entity._PessoaProcesso;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._PessoaProcesso;

namespace GestaoProduto.Dados.Repositorio._Pessoa
{
    public class PessoaProcessoRepositorio : RepositorioBase<PessoaProcesso>, IPessoaProcessoRepositorio
    {
        public PessoaProcessoRepositorio(ApplicationDbContext context) : base(context)
        { }

        
    }
}
