using System.Collections.Generic;
using System.Threading.Tasks;
using GestaoProduto.Dominio.Entity._TipoPessoa;
using GestaoProduto.Compartilhado.Model._TipoPessoa;
using GestaoProduto.Dominio.Entity._PessoaProcesso;

namespace GestaoProduto.Compartilhado.Interfaces.Servico._TipoPessoa
{
    public interface ITipoPessoaServico
    {
        Task<List<TipoPessoa>> Listar();
        Task<List<TipoPessoa>> listarTipoPessoasCompleta();
        Task<TipoPessoaModel> ObterPorId(int id);
        Task<List<TipoPessoa>> BuscaPorTermo(string termo);
        Task<TipoPessoa> Adicionar(TipoPessoaModel tipoPessoaModel);
        Task<PessoaProcesso> Associar(TipoPessoaModel model, int processoId, int pessoaId);
        Task<TipoPessoa> Editar(TipoPessoaModel tipoPessoaModel);
        Task<string> Delete(int id);        

    }
}