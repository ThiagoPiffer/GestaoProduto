using System.Collections.Generic;
using System.Threading.Tasks;
using GestaoProduto.Compartilhado.Model._ControlePessoaExterna;
using GestaoProduto.Compartilhado.Model._TipoPessoa;
using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity;
using GestaoProduto.Dominio.Entity._ControlePessoaExterna;
using GestaoProduto.Dominio.Entity._TipoPessoa;

namespace GestaoProduto.Compartilhado.Interfaces.Servico._ControlePessoaExterna
{
    public interface IControlePessoaExternaServico
    {        
        Task<List<ControlePessoaExterna>> Listar();
        Task<ControlePessoaExternaModel> ObterPorId(int id);
        Task<ControlePessoaExterna> Adicionar(string dataExpiracao);
        Task<ControlePessoaExterna> Editar(ControlePessoaExternaModel tipoPessoaModel);
        Task<string> Delete(int id);
        Task<ControlePessoaExternaModel> Validar(string id);

    }
}
