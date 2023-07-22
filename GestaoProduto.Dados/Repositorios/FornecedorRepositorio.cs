using GestaoProduto.Dados.Contextos;
using GestaoProduto.Dominio.Entity;
using GestaoProduto.Dominio.Repositorio;

namespace GestaoProduto.Dados.Repositorios
{
    public class FornecedorRepositorio : RepositorioBase<Fornecedor>, IFornecedorRepositorio
    {
        public FornecedorRepositorio(ApplicationDbContext context) : base(context)
        {
        }

        public Fornecedor ObterPeloCNPJ(string cnpj)
        {
            var fornecedores = Context.Set<Fornecedor>().Where(a => a.Ativo && a.CNPJ == cnpj);
            return fornecedores.Any() ? fornecedores.First() : null;
        }

        public bool ContemDuplicidadeCNPJ(FornecedorDto fornecedorDto)
        {
            var quantidade = Context.Set<Fornecedor>().ToList().Where(a => a.Ativo && a.CNPJ == fornecedorDto.CNPJ && a.Id != fornecedorDto.Id).Count();
            return quantidade > 1 ? true : false;
        }

        public bool ExisteCNPJ(string cnpj)
        {
            var quantidade = Context.Set<Fornecedor>().Where(a => a.Ativo && a.CNPJ == cnpj).Count();
            return quantidade == 0 ? true : false;
        }
    }
}

