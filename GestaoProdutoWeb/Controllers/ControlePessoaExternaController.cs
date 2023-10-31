using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GestaoProduto.Dominio.Entity._ControlePessoaExterna;
using GestaoProduto.Compartilhado.Interfaces.Servico._ControlePessoaExterna;
using GestaoProduto.Compartilhado.Model._ControlePessoaExterna;

namespace GestaoProduto.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControlePessoaExternaController : ControllerBase
    {
        private readonly IControlePessoaExternaServico _controlePessoaExternaServico;

        public class DataExpiracaoModel
        {
            public string DataExpiracao { get; set; }
        }

        public ControlePessoaExternaController(IControlePessoaExternaServico controlePessoaExternaServico)
        {
            _controlePessoaExternaServico = controlePessoaExternaServico;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> Listar()
        {
            return Ok(await _controlePessoaExternaServico.Listar());
        }

        [HttpGet]
        [Route("ObterPorId")]
        public async Task<IActionResult> ObterPorId([FromQuery] int id)
        {
            return Ok(await _controlePessoaExternaServico.ObterPorId(id));
        }

        [HttpPost]
        [Route("Adicionar")]
        public async Task<IActionResult> Adicionar([FromBody] DataExpiracaoModel model)
        {
            ControlePessoaExterna controlePessoaExterna = await _controlePessoaExternaServico.Adicionar(model.DataExpiracao);
            return Ok(controlePessoaExterna);
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] ControlePessoaExternaModel controlePessoaExternaModel)
        {
            ControlePessoaExterna controlePessoaExterna = await _controlePessoaExternaServico.Editar(controlePessoaExternaModel);
            return Ok(controlePessoaExterna);
        }

        [HttpDelete]
        [Route("Deletar")]
        public async Task<IActionResult> Deletar([FromQuery] int id)
        {
            return Ok(new { mensagem = await _controlePessoaExternaServico.Delete(id) });
        }

        [HttpGet]
        [Route("Validar")]
        public async Task<IActionResult> Validar([FromQuery] string id)
        {            
            ControlePessoaExternaModel controlePessoaExterna = await _controlePessoaExternaServico.Validar(id);
            return Ok(controlePessoaExterna);
        }
    }
}
