using System.Collections.Generic;
using System.Threading.Tasks;
using GestaoProduto.Dominio.Entity._TipoPessoa;
using GestaoProduto.Dominio.Model._TipoPessoa;

namespace GestaoProduto.Dominio.IServico._TipoPessoa
{
    public interface ITipoPessoaServico
    {
        Task<List<TipoPessoa>> Listar();
        Task<TipoPessoaModel> ObterPorId(int id);
        Task<List<TipoPessoa>> BuscaPorTermo(string termo);
        Task<TipoPessoa> Adicionar(TipoPessoaModel tipoPessoaModel);
        Task<TipoPessoa> Editar(TipoPessoaModel tipoPessoaModel);
        Task<string> Delete(int id);        

    }
}