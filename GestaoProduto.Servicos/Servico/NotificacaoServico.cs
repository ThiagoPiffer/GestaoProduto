using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._TipoPessoa;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._TipoPessoa;
using GestaoProduto.Compartilhado.Interfaces.Servico._Notificacao;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._Notificacao;
using GestaoProduto.Compartilhado.Interfaces._User;

namespace GestaoProduto.Servico._Notificacao
{
    public class NotificacaoServico : INotificacaoServico
    {
        private readonly INotificacaoRepositorio _notificacaoRepositorio;
        private readonly IUser _user;

        public NotificacaoServico(
            INotificacaoRepositorio notificacaoRepositorio,
            IUser user
            )
        {
            _notificacaoRepositorio = notificacaoRepositorio;
            _user = user;
        }

        public async Task<int> Quantidade()
        {
            var empresaId = _user.EmpresaCurrent.Id;
            return await _notificacaoRepositorio.Quantidade(empresaId);
        }       
    }
}