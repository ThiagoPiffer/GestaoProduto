using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GestaoProduto.Dominio.Entity._TipoPessoa;
using GestaoProduto.Compartilhado.Interfaces.Servico._TipoPessoa;
using GestaoProduto.Compartilhado.Model._TipoPessoa;
using GestaoProduto.Dominio.Entity._PessoaProcesso;

namespace GestaoProduto.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoPessoaController : ControllerBase
    {
        private readonly ITipoPessoaServico _tipoPessoaServico;

        public TipoPessoaController(ITipoPessoaServico tipoPessoaServico)
        {
            _tipoPessoaServico = tipoPessoaServico;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> Listar()
        {
            return Ok(await _tipoPessoaServico.Listar());
        }

        [HttpGet]
        [Route("listarTipoPessoasCompleta")]
        public async Task<IActionResult> listarTipoPessoasCompleta()
        {
            return Ok(await _tipoPessoaServico.listarTipoPessoasCompleta());
        }

        [HttpGet]
        [Route("listarTipoPessoasProcesso")]
        public async Task<IActionResult> listarTipoPessoasProcesso(int processoId)
        {
            return Ok(await _tipoPessoaServico.listarTipoPessoasProcesso(processoId));
        }

        [HttpGet]
        [Route("ObterPorId")]
        public async Task<IActionResult> ObterPorId([FromQuery] int id)
        {
            return Ok(await _tipoPessoaServico.ObterPorId(id));
        }

        [HttpPost]
        [Route("Adicionar")]
        public async Task<IActionResult> Adicionar([FromBody] TipoPessoaModel tipoPessoaModel)
        {
            TipoPessoa tipoPessoa = await _tipoPessoaServico.Adicionar(tipoPessoaModel);
            return Ok(tipoPessoa);
        }

        [HttpPost]
        [Route("Associar")]
        public async Task<IActionResult> Associar([FromBody] TipoPessoaModel tipoPessoaModel, int processoId, int pessoaId)
        {
            PessoaProcesso tipoPessoa = await _tipoPessoaServico.Associar(tipoPessoaModel, processoId, pessoaId);
            return Ok(tipoPessoa);
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] TipoPessoaModel tipoPessoaModel)
        {
            TipoPessoa tipoPessoa = await _tipoPessoaServico.Editar(tipoPessoaModel);
            return Ok(tipoPessoa);
        }

        [HttpDelete]
        [Route("Deletar")]
        public async Task<IActionResult> Deletar([FromQuery] int id)
        {
            return Ok(new { mensagem = await _tipoPessoaServico.Delete(id) });
        }
    }
}
