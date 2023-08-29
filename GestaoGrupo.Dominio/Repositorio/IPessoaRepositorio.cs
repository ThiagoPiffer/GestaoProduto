using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity;
using GestaoProduto.Dominio.Model;

namespace GestaoProduto.Dominio.Repositorio
{
    public interface IPessoaRepositorio : IRepositorio<Pessoa>
    {
        Task<List<PessoasProcessoModel>> ListarPessoasProcesso(int idProcesso);

    }
}
