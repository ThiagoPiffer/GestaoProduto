using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity;

namespace GestaoProduto.Dominio.Repositorio
{
    public interface IPessoaRepositorio : IRepositorio<Pessoa>
    {
        Pessoa ObterPeloCNPJ(string cnpj);
        Pessoa ObterPorEmail(string email);
        bool ContemDuplicidadeCNPJ(PessoaDto pessoaDto);
    }
}
