using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._Pessoa;
using GestaoProduto.Dominio.Model._PessoaProcesso;

namespace GestaoProduto.Dominio.IRepositorio._Pessoa
{
    public interface IPessoaRepositorio : IRepositorio<Pessoa>
    {
        Task<List<PessoaProcessoModel>> ListarPessoasProcesso(int idProcesso);
        Task<List<PessoaProcessoModel>> ListarPessoasArquivoTemplate(int idArquivoTemplate, int idProcesso, List<int> idsTiposPessoa);        
    }
}
