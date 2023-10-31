using System.Collections.Generic;
using System.Threading.Tasks;
using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._TipoPessoa;

namespace GestaoProduto.Compartilhado.Interfaces.Repositorio._TipoPessoa
{
    public interface ITipoPessoaRepositorio : IRepositorio<TipoPessoa>
    {
        Task<List<TipoPessoa>> BuscaPorTermo(string termo);
        Task<TipoPessoa> BurcaPorId(int id);
        Task Armazenar(TipoPessoa tipoPessoa);
        void Update(TipoPessoa tipoPessoa);        
    }
}