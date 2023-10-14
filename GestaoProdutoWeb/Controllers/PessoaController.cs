using GestaoProduto.Core.Identidade;
using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity;
using GestaoProduto.Dominio.Model;
using GestaoProduto.Dominio.Servico;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace GestaoProduto.API.Controllers
{
    [Route("api/[controller]")]
    
    //[AllowAnonymous]
    
    public class PessoaController : Controller
    {
        private readonly IRepositorio<Pessoa> _repositorio;
        private readonly IPessoaServico _pessoaServico;

        public PessoaController(IRepositorio<Pessoa> repositorio,
                                IPessoaServico pessoaServico)
        {
            _repositorio = repositorio;
            _pessoaServico = pessoaServico;
        }

        [HttpGet]
        [Route("Listar")]
        //[ClaimsAuthorize("API","Ler")]
        public async Task<IActionResult> Listar()
        {
            return Ok(await _pessoaServico.Listar());
        }

        [HttpGet]
        [Route("ListarPessoasProcesso")]
        public async Task<IActionResult> ListarPessoasProcesso([FromQuery] int idProcesso)
        {
            return Ok(await _pessoaServico.ListarPessoasProcesso(idProcesso));
        }

        [HttpGet]
        [Route("ObterPorId")]
        public async Task<IActionResult> ObterPorId([FromQuery] int id)
        {
            return Ok(await _pessoaServico.ObterPorId(id));
        }

        [HttpPost]
        [Route("Adicionar")]
        public async Task<IActionResult> Adicionar([FromBody] PessoaModel pessoaDto, [FromQuery] int idProcesso)
        {
            Pessoa pessoa = await _pessoaServico.Adicionar(pessoaDto, idProcesso);
            return Ok(pessoa);
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] PessoaModel pessoaDto)
        {
            Pessoa pessoa = await _pessoaServico.Editar(pessoaDto);
            return Ok(pessoa);
        }

        [HttpDelete]
        [Route("Deletar")]
        public async Task<IActionResult> Deletar([FromQuery] int id)
        {
            return Ok(new { mensagem = await _pessoaServico.Delete(id) });
        }
    }
}
