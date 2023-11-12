using System.Collections.Generic;
using System.Threading.Tasks;
using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._TipoPessoa;

namespace GestaoProduto.Compartilhado.Interfaces.Repositorio._Notificacao
{
    public interface INotificacaoRepositorio 
    {
        Task<int> Quantidade(int empresaId);
    }
}