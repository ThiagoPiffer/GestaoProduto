using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._Pessoa;
using GestaoProduto.Dominio.Model._PessoasProcesso;

namespace GestaoProduto.Dominio.IRepositorio._Pessoa
{
    public interface IPessoaRepositorio : IRepositorio<Pessoa>
    {
        Task<List<PessoasProcessoModel>> ListarPessoasProcesso(int idProcesso);
        Task<List<PessoasProcessoModel>> ListarPessoasArquivoTemplate(int idArquivoTemplate, int idProcesso, List<int> idsTiposPessoa);        
    }
}
