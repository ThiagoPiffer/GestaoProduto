using GestaoProduto.Dominio.Entity._Pessoa;
using GestaoProduto.Compartilhado.Model._Pessoa;
using GestaoProduto.Compartilhado.Model._PessoaProcesso;

namespace GestaoProduto.Compartilhado.Interfaces.Servico._Pessoa
{
    public interface IPessoaServico
    {
        Task<List<Pessoa>> Listar();
        Task<List<PessoaProcessoModel>> ListarPessoasProcesso(int idProcesso);
        Task<List<PessoaProcessoModel>> listarPessoasAssociar(int idProcesso);
        Task<List<PessoaProcessoModel>> ListarPessoasCompleta();
        Task<List<PessoaProcessoModel>> listarPessoasExterna();
        Task<PessoaModel> ObterPorId(int id);
        Task<Pessoa> Adicionar(PessoaModel pessoaModel, int idProcesso);
        Task<PessoaProcessoModel> Associar(PessoaProcessoModel pessoaModel, int idProcesso);
        Task<Pessoa> AdicionarCadastroExterno(PessoaModel pessoaModel);
        Task<Pessoa> Editar(PessoaModel pessoaModel);
        Task<string> Delete(int id);
        Task<string> DesassociarPessoaProcesso(int idPessoa, int idProcesso);        

    }
}
