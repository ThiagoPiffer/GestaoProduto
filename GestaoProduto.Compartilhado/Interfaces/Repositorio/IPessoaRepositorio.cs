using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._Pessoa;
using GestaoProduto.Compartilhado.Model._PessoaProcesso;

namespace GestaoProduto.Compartilhado.Interfaces.Repositorio._Pessoa
{
    public interface IPessoaRepositorio : IRepositorio<Pessoa>
    {
        Task<List<PessoaProcessoModel>> ListarPessoasProcesso(int idProcesso, int empresaId, bool pessoasNoProcesso = true, bool buscaCompleta = false);
        Task<List<PessoaProcessoModel>> ListarPessoasArquivoTemplate(int idArquivoTemplate, int idProcesso, int empresaId, List<int> idsTiposPessoa);        
    }
}
