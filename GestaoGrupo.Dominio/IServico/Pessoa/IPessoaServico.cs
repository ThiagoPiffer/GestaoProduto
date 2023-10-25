using GestaoProduto.Dominio.Entity._Pessoa;
using GestaoProduto.Dominio.Model._Pessoa;
using GestaoProduto.Dominio.Model._PessoaProcesso;

namespace GestaoProduto.Dominio.IServico._Pessoa
{
    public interface IPessoaServico
    {
        Task<List<Pessoa>> Listar();
        Task<List<PessoaProcessoModel>> ListarPessoasProcesso(int idProcesso);
        Task<PessoaModel> ObterPorId(int id);
        Task<Pessoa> Adicionar(PessoaModel pessoaModel, int idProcesso);
        Task<Pessoa> Editar(PessoaModel pessoaModel);
        Task<string> Delete(int id);
    }
}
