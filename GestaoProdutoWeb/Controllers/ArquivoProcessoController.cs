using GestaoProduto.Dominio._Base;
using GestaoProduto.Compartilhado.Model._ArquivoProcesso;
using GestaoProduto.Compartilhado.Interfaces.Servico._ArquivoProcesso;
using GestaoProduto.Servico;
using Microsoft.AspNetCore.Mvc;
using GestaoProduto.Dominio.Entity;
using GestaoProduto.Dominio.Entity._ArquivoProcesso;

namespace GestaoProduto.API.Controllers
{
    [Route("api/[controller]")]
    public class ArquivoProcessoController : Controller
    {
        private readonly IRepositorio<ArquivoProcesso> _repositorio;
        private readonly IArquivoProcessoServico _arquivoProcesso;

        public ArquivoProcessoController(IRepositorio<ArquivoProcesso> repositorio,
                                IArquivoProcessoServico arquivoProcesso)
        {
            _repositorio = repositorio;
            _arquivoProcesso = arquivoProcesso;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> Listar()
        {
            return Ok(await _arquivoProcesso.Listar());
        }

        [HttpGet]
        [Route("listarArquivosProcesso")]
        public async Task<IActionResult> listarArquivosProcesso([FromQuery] int idProcesso)
        {
            return Ok(await _arquivoProcesso.ListarArquivosProcesso(idProcesso));
        }
        

        [HttpGet]
        [Route("ObterPorId")]
        public async Task<IActionResult> ObterPorId([FromQuery] int id)
        {
            return Ok(await _arquivoProcesso.ObterPorId(id));
        }

        [HttpPost]
        [Route("Adicionar")]
        public async Task<IActionResult> Adicionar([FromForm(Name = "arquivoProcesso")] ArquivoProcessoModel arquivoProcessoModal, [FromForm] IFormFile file)
        {

            // Converta o IFormFile em Stream para passá-lo para o serviço
            using (var stream = file.OpenReadStream())
            {
                var result = await _arquivoProcesso.Adicionar(arquivoProcessoModal, stream);

                if (result != null)
                    return Ok(result);
                else
                    return BadRequest("Erro ao adicionar o arquivo.");
            }
        }

        [HttpGet("DownloadArquivo/{id}")]
        public async Task<IActionResult> DownloadArquivo(int id)
        {
            // 1. Busque o arquivo pelo ID
            var arquivo = await _arquivoProcesso.ObterPorId(id);
            if (arquivo == null) return NotFound();

            // 2. Leia o arquivo do sistema de arquivos
            var path = arquivo.CaminhoArquivo;
            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            // 3. Retorne o arquivo para download
            var extensao = Path.GetExtension(path).ToLowerInvariant();
            return File(memory, GetContentType(extensao), arquivo.NomeArquivo);
        }

        //[HttpGet("DownloadArquivo/{id}")]
        //public IActionResult DownloadArquivo(int id)
        //{
        //    // 1. Busque o arquivo pelo ID
        //    var result = _arquivoProcesso.ObterPorId(id);
        //    var arquivo = result.Result;
        //    if (arquivo == null) return NotFound();

        //    // 2. Leia o arquivo do sistema de arquivos
        //    var path = arquivo.CaminhoArquivo;
        //    var memory = new MemoryStream();
        //    using (var stream = new FileStream(path, FileMode.Open))
        //    {
        //        stream.CopyToAsync(memory);
        //    }
        //    memory.Position = 0;

        //    // 3. Retorne o arquivo para download
        //    var extensao = Path.GetExtension(path).ToLowerInvariant();
        //    return File(memory, GetContentType(extensao), arquivo.NomeArquivo);
        //}

        private static string GetContentType(string fileExtension)
        {
            // TODO: Mapeie mais extensões se necessário.
            var types = new Dictionary<string, string>
            {
                {".pdf", "application/pdf"},
                {".doc", "application/msword"},
                {".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document"},
                {".png", "image/png"},
                {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
                // ... outros tipos de arquivo se necessário
            };

            if (types.TryGetValue(fileExtension, out string contentType))
            {
                return contentType;
            }

            return "application/octet-stream"; // Tipo genérico para dados binários desconhecidos
        }






        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] ArquivoProcessoModel pessoaDto)
        {
            ArquivoProcesso pessoa = await _arquivoProcesso.Editar(pessoaDto);
            return Ok(pessoa);
        }

        [HttpPut]
        [Route("EditarDescricao")]
        public async Task<IActionResult> Editar([FromQuery] int id, string descricao)
        {
            ArquivoProcesso pessoa = await _arquivoProcesso.EditarDescricao(id, descricao);
            return Ok(pessoa);
        }

        [HttpDelete]
        [Route("Deletar")]
        public async Task<IActionResult> Deletar([FromQuery] int id)
        {
            return Ok(new { mensagem = await _arquivoProcesso.Delete(id) });
        }
    }
}
