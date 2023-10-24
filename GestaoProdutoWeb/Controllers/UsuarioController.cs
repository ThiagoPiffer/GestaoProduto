using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._Usuario;
using GestaoProduto.Dominio.Model._Usuario;
using GestaoProduto.Dominio.IServico._Usuario;
using Microsoft.AspNetCore.Mvc;

namespace GestaoProduto.API.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {        
        private readonly IUsuarioServico _usuarioServico;

        public UsuarioController(
            IUsuarioServico usuarioServico
            )
        {
            _usuarioServico = usuarioServico;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> Listar()
        {
            return Ok(await _usuarioServico.Listar());
        }

        [HttpGet]
        [Route("ObterPorId")]
        public async Task<IActionResult> ObterPorId([FromQuery] int id)
        {
            return Ok(await _usuarioServico.ObterPorId(id));
        }

        [HttpPost]
        [Route("Adicionar")]
        public async Task<IActionResult> Adicionar([FromBody] UsuarioModel usuarioModel)
        {
            Usuario usuario = await _usuarioServico.Adicionar(usuarioModel);
            return Ok(usuario);  
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] UsuarioModel usuarioModel)
        {
            Usuario usuario = await _usuarioServico.Editar(usuarioModel);
            return Ok(usuario);
        }

        [HttpDelete]
        [Route("Deletar")]
        public async Task<IActionResult> Deletar([FromQuery] int id)
        {
            return Ok( new { mensagem = await _usuarioServico.Delete(id) });            
        }
    }
}
