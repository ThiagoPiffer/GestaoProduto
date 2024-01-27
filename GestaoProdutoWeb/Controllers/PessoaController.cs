using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._Pessoa;
using GestaoProduto.Compartilhado.Model._Pessoa;
using GestaoProduto.Compartilhado.Interfaces.Servico._Pessoa;
using Microsoft.AspNetCore.Mvc;
using GestaoProduto.Compartilhado.Interfaces._User;
using GestaoProduto.Compartilhado.Model._PessoaProcesso;
using Microsoft.AspNetCore.Authorization;

namespace GestaoProduto.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]

    public class PessoaController : Controller
    {        
        private readonly IPessoaServico _pessoaServico;
        private readonly IUser _user;

        public PessoaController(
                                IPessoaServico pessoaServico,
                                IUser user)
        {            
            _pessoaServico = pessoaServico;
            _user=user;
        }

        [HttpPost]
        [Route("Listar")]
        public async Task<IActionResult> Listar([FromBody] object request)
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
        [Route("ListarPessoasCompleta")]
        public async Task<IActionResult> ListarPessoasCompleta()
        {
            return Ok(await _pessoaServico.ListarPessoasCompleta());
        }

        [HttpGet]
        [Route("listarPessoasAssociar")]
        public async Task<IActionResult> listarPessoasAssociar([FromQuery] int idProcesso)
        {
            return Ok(await _pessoaServico.listarPessoasAssociar(idProcesso));
        }

        [HttpGet]
        [Route("listarPessoasExterna")]
        public async Task<IActionResult> listarPessoasExterna()
        {            
            return Ok(await _pessoaServico.listarPessoasExterna());
        }        

        [HttpGet]
        [Route("ObterPorId")]
        public async Task<IActionResult> ObterPorId([FromQuery] int id)
        {
            return Ok(await _pessoaServico.ObterPorId(id));
        }

        [HttpPost]
        [Route("Adicionar")]
        public async Task<IActionResult> Adicionar([FromBody] PessoaModel pessoaModel)
        {
            Pessoa pessoa = await _pessoaServico.Adicionar(pessoaModel);
            return Ok(pessoa);
        }

        [HttpPost]
        [Route("Associar")]
        public async Task<IActionResult> Associar([FromBody] PessoaProcessoModel pessoaModel, [FromQuery] int idProcesso)
        {
            var result = await _pessoaServico.Associar(pessoaModel, idProcesso);
            return Ok( result );
        }

        [HttpPost]
        [Route("AdicionarCadastroExterno")]
        [AllowAnonymous]
        public async Task<IActionResult> AdicionarCadastroExterno([FromBody] PessoaModel pessoaModel)
        {
            Pessoa pessoa = await _pessoaServico.AdicionarCadastroExterno(pessoaModel);
            return Ok(pessoa);
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] PessoaModel pessoaModel)
        {
            Pessoa pessoa = await _pessoaServico.Editar(pessoaModel);
            return Ok(pessoa);
        }

        [HttpDelete]
        [Route("Deletar")]
        public async Task<IActionResult> Deletar([FromQuery] int id)
        {
            return Ok(new { mensagem = await _pessoaServico.Delete(id) });
        }
        
        [HttpGet]
        [Route("DesassociarPessoaProcesso")]
        public async Task<IActionResult> DesassociarPessoaProcesso([FromQuery] int idPessoa, int idProcesso)
        {            
            return Ok(new { message = await _pessoaServico.DesassociarPessoaProcesso(idPessoa, idProcesso) });
        }
    }
}
