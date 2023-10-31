using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._ArquivoProcessoTemplate;
using GestaoProduto.Dominio.Entity._TipoPessoaTemplate;
using GestaoProduto.Dominio.Model._TipoPessoaTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProduto.Compartilhado.Interfaces.Repositorio._TipoPessoaTemplateRepositorio
{
    public interface ITipoPessoaTemplateRepositorio : IRepositorio<TipoPessoaTemplate>
    {
        Task AdicionarTipoPessoaTemplate(List<TipoPessoaTemplate> lista);
        List<TipoPessoaTemplateModel> ListarTiposPessoaTemplate(int idProccessoTemplate);
    }
}
