using GestaoProduto.Dominio.Entity._Pessoa;
using GestaoProduto.Dominio.Model._Pessoa;
using GestaoProduto.Dominio.Model._PessoasProcesso;

namespace GestaoProduto.Dominio.IServico._Pessoa
{
    public interface IPessoaServico
    {
        Task<List<Pessoa>> Listar();
        Task<List<PessoasProcessoModel>> ListarPessoasProcesso(int idProcesso);
        Task<PessoaModel> ObterPorId(int id);
        Task<Pessoa> Adicionar(PessoaModel pessoaModel, int idProcesso);
        Task<Pessoa> Editar(PessoaModel pessoaModel);
        Task<string> Delete(int id);
    }
}
