using GestaoProduto.Dominio.Entity;
using GestaoProduto.Dominio.Model;

namespace GestaoProduto.Dominio.Servico
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
