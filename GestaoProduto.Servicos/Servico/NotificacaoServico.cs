using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._TipoPessoa;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._TipoPessoa;
using GestaoProduto.Compartilhado.Interfaces.Servico._Notificacao;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._Notificacao;

namespace GestaoProduto.Servico._Notificacao
{
    public class NotificacaoServico : INotificacaoServico
    {
        private readonly INotificacaoRepositorio _notificacaoRepositorio;

        public NotificacaoServico(INotificacaoRepositorio notificacaoRepositorio)
        {
            _notificacaoRepositorio = notificacaoRepositorio;
        }

        public async Task<int> Quantidade()
        {
            return await _notificacaoRepositorio.Quantidade();
        }       
    }
}