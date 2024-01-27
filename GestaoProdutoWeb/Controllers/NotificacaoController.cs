using GestaoProduto.Compartilhado.Interfaces.Servico._Notificacao;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestaoProduto.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class NotificacaoController : Controller
    {        
        private readonly INotificacaoServico _notificacaoServico;

        public NotificacaoController(
                                INotificacaoServico notificacaoServico)
        {
            _notificacaoServico = notificacaoServico;
        }

        [HttpGet]
        [Route("Quantidade")]
        public async Task<IActionResult> Quantidade()
        {
            return Ok(await _notificacaoServico.Quantidade());
        }
    }
}
