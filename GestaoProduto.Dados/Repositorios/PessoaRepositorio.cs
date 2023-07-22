using GestaoProduto.Dados.Contextos;
using GestaoProduto.Dominio.Entity;
using GestaoProduto.Dominio.Repositorio;

namespace GestaoProduto.Dados.Repositorios
{
    public class PessoaRepositorio : RepositorioBase<Pessoa>, IPessoaRepositorio
    {
        public PessoaRepositorio(ApplicationDbContext context) : base(context)
        { }

        public Pessoa ObterPeloCNPJ(string cnpj)
        {
            var pessoas = Context.Set<Pessoa>().Where(a => a.Ativo && a.CPFCNPJ == cnpj);
            return pessoas.Any() ? pessoas.First() : null!;
        }

        public Pessoa ObterPorEmail(string email)
        {
            var pessoas = Context.Set<Pessoa>().Where(a => a.Ativo && a.Email == email);
            return pessoas.Any() ? pessoas.First() : null!;
        }

        public bool ContemDuplicidadeCNPJ(PessoaDto pessoaDto)
        {
            var quantidade = Context.Set<Pessoa>().ToList().Where(a => a.Ativo && a.CPFCNPJ == pessoaDto.CPFCNPJ && a.Id != pessoaDto.Id).Count();
            return quantidade > 1 ? true : false;
        }
    }
}
