using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._ArquivoProcessoTemplate;
using GestaoProduto.Compartilhado.Model._ArquivoProcessoTemplate;
using GestaoProduto.Compartilhado.Interfaces.Servico._ArquivoProcessoTemplate;
using GestaoProduto.Compartilhado.Interfaces.Servico._Pessoa;
using GestaoProduto.Compartilhado.Interfaces.Servico._TipoPessoaTemplateServico;
using Microsoft.AspNetCore.Mvc;
using Xceed.Words.NET;
using GestaoProduto.Compartilhado.Model._PessoaProcesso;
using GestaoProduto.Dominio.Model._TipoPessoaTemplate;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using GestaoProduto.Compartilhado._ConfiguracaoTemplateModel;

namespace GestaoProduto.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]

    public class ArquivoProcessoTemplateController : Controller
    {
        private readonly IRepositorio<ArquivoProcessoTemplate> _repositorio;        
        private readonly IArquivoProcessoTemplateServico _arquivoProcessoTemplateServico;
        private readonly ITipoPessoaTemplateServico _tipoPessoaTemplateServico;
        private readonly IPessoaServico _pessoaServico;

        public ArquivoProcessoTemplateController(
                                    IRepositorio<ArquivoProcessoTemplate> repositorio,
                                    IArquivoProcessoTemplateServico arquivoProcessoTemplateServico,
                                    ITipoPessoaTemplateServico tipoPessoaTemplateServico,
                                    IPessoaServico pessoaServico
            )
        {
            _repositorio = repositorio;
            _arquivoProcessoTemplateServico = arquivoProcessoTemplateServico;
            _tipoPessoaTemplateServico=tipoPessoaTemplateServico;
            _pessoaServico = pessoaServico;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> Listar()
        {
            return Ok(await _arquivoProcessoTemplateServico.Listar());
        }

        [HttpGet]
        [Route("ObterPorId")]
        public async Task<IActionResult> ObterPorId([FromQuery] int id)
        {
            return Ok(await _arquivoProcessoTemplateServico.ObterPorId(id));
        }

        [HttpPost]
        [Route("Adicionar")]
        public async Task<IActionResult> Adicionar([FromQuery] int idProcesso, [FromForm] IFormFile file, [FromForm] string tipoPessoaTemplateModel)
        {
            // Deserializar tipoPessoaTemplateModel de volta para uma lista
            var tiposPessoaTemplateModel = JsonConvert.DeserializeObject<List<TipoPessoaTemplateModel>>(tipoPessoaTemplateModel);

            ArquivoProcessoTemplate arquivoprocessotemplate = await _arquivoProcessoTemplateServico.Adicionar(idProcesso, file, tiposPessoaTemplateModel);

            if (arquivoprocessotemplate != null)
                return Ok(arquivoprocessotemplate);
            else
                return BadRequest("Erro ao adicionar o arquivo.");
        }


        [HttpPost]
        [Route("AdicionarTipoPessoaTemplate")]
        public async Task<IActionResult> AdicionarTipoPessoaTemplate([FromBody] List<TipoPessoaTemplateModel> tiposPessoa)
        {
            await _tipoPessoaTemplateServico.AdicionarTipoPessoaTemplate(tiposPessoa);
            return Ok();
        }

        [HttpPost("DownloadArquivoTemplate")]
        public async Task<IActionResult> DownloadArquivo([FromBody] ConfiguracaoTemplateModel configuracaoTemplate)
        {
            // 1. Busque o arquivo pelo ID
            var arquivo = await _arquivoProcessoTemplateServico.ObterPorId(configuracaoTemplate.IdArquivoTemplate);
            if (arquivo == null) return NotFound();

            // 2. Leia o arquivo do sistema de arquivos
            var path = arquivo.CaminhoArquivo;

            var memory = new MemoryStream();

            // Carregue o documento usando DocX
            using (DocX document = DocX.Load(path))
            {
                foreach (var pessoa in configuracaoTemplate.ListaPessoa)
                {
                    if (pessoa.Value == null) return NotFound();

                    var Pessoa = await _pessoaServico.ObterPorId(pessoa.Value.Id);

                    var chave = configuracaoTemplate.ListaTipos.First(l => l.Id == pessoa.Key).CampoChave;

                    // Use o método ReplaceText com o objeto StringReplaceTextOptions
                    document.ReplaceText("{{nome" + chave + "}}", Pessoa.Nome ?? "");
                    document.ReplaceText("{{cpfcnpj" + chave + "}}", Pessoa.CPFCNPJ ?? "");
                    document.ReplaceText("{{email" + chave + "}}", Pessoa.Email ?? "");
                    document.ReplaceText("{{identidade" + chave + "}}", Pessoa.Identidade ?? "");
                    document.ReplaceText("{{dataNascimento" + chave + "}}", Pessoa.DataNascimento ?? "");
                    document.ReplaceText("{{telefone" + chave + "}}", Pessoa.Telefone ?? "");
                    document.ReplaceText("{{celular" + chave + "}}", Pessoa.Celular ?? "");                    

                    document.ReplaceText("{{profissao" + chave + "}}", Pessoa.Profissao ?? "");
                    document.ReplaceText("{{nacionalidade" + chave + "}}", Pessoa.Nacionalidade ?? "");
                    document.ReplaceText("{{estadocivil" + chave + "}}", Pessoa.EstadoCivil ?? "");

                    if (Pessoa.Endereco != null)
                    { 
                        document.ReplaceText("{{numero" + chave + "}}", Pessoa.Endereco.Numero ?? "");
                        document.ReplaceText("{{rua" + chave + "}}", Pessoa.Endereco.Rua ?? "");
                        document.ReplaceText("{{bairro" + chave + "}}", Pessoa.Endereco.Bairro ?? "");
                        document.ReplaceText("{{cidade" + chave + "}}", Pessoa.Endereco.Cidade ?? "");
                        document.ReplaceText("{{estado" + chave + "}}", Pessoa.Endereco.Estado ?? "");
                        document.ReplaceText("{{cep" + chave + "}}", Pessoa.Endereco.CEP ?? "");
                    }
                }

                // Salve o documento em um MemoryStream após todas as substituições terem sido feitas
                document.SaveAs(memory);
            }

            memory.Position = 0;

            // 3. Retorne o arquivo para download
            var extensao = Path.GetExtension(path).ToLowerInvariant();
            return File(memory, GetContentType(extensao), Path.GetFileName(path));
        }



        //[HttpPost("DownloadArquivoTemplate")]
        //public async Task<IActionResult> DownloadArquivo([FromBody] ConfiguracaoTemplateModel configuracaoTemplate)
        //{
        //    // 1. Busque o arquivo pelo ID
        //    var arquivo = await _arquivoProcessoTemplateServico.ObterPorId(configuracaoTemplate.IdArquivoTemplate);
        //    if (arquivo == null) return NotFound();

        //    // 2. Leia o arquivo do sistema de arquivos
        //    var path = arquivo.CaminhoArquivo;

        //    var memory = new MemoryStream();
        //    foreach (var pessoa in configuracaoTemplate.ListaPessoa)
        //    {
        //        if (pessoa.Value == null) return NotFound();

        //        var chave = configuracaoTemplate.ListaTipos.First(l => l.Id == pessoa.Key).CampoChave;

        //        // Carregue o documento usando DocX
        //        using (DocX document = DocX.Load(path))
        //        {

        //            // Use o método ReplaceText com o objeto StringReplaceTextOptions
        //            document.ReplaceText("{{nome"+ chave +"}}", pessoa.Value.Nome ?? "");
        //            document.ReplaceText("{{cpf"+ chave +"}}", pessoa.Value.Cpfcnpj);
        //            document.ReplaceText("{{email"+ chave +"}}", pessoa.Value.Email);
        //            document.ReplaceText("{{identidade"+ chave +"}}", pessoa.Value.Identidade);
        //            document.ReplaceText("{{dataNascimento"+ chave +"}}", pessoa.Value.DataNascimento);
        //            document.ReplaceText("{{telefone"+ chave +"}}", pessoa.Value.Telefone);
        //            document.ReplaceText("{{celular"+ chave +"}}", pessoa.Value.Celular);

        //            // Salve o documento em um MemoryStream                    
        //            document.SaveAs(memory);
        //            memory.Position = 0;
        //        }
        //    }
        
        //    // 3. Retorne o arquivo para download
        //    var extensao = Path.GetExtension(path).ToLowerInvariant();
        //    return File(memory, GetContentType(extensao), Path.GetFileName(path));
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
                // ... outros tipos de arquivo se necessário
            };
            return types[fileExtension];
        }

        [HttpGet("ListarPessoaTemplate/{idArquivoTemplate}/{idProcesso}")]
        public Task<List<PessoaProcessoModel>> ListarPessoaTemplate(int idArquivoTemplate, int idProcesso)
        {            
            return _tipoPessoaTemplateServico.ListarPessoaTemplate(idArquivoTemplate, idProcesso);
        }

        [HttpGet("ListarTiposPessoaTemplate/{idProccessoTemplate}")]
        public List<TipoPessoaTemplateModel> ListarTiposPessoaTemplate(int idProccessoTemplate)
        {
            var result = _tipoPessoaTemplateServico.ListarTiposPessoaTemplate(idProccessoTemplate);
            return result;
        }
        

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] ArquivoProcessoTemplateModel arquivoprocessotemplateModel)
        {
            ArquivoProcessoTemplate arquivoprocessotemplate = await _arquivoProcessoTemplateServico.Editar(arquivoprocessotemplateModel);
            return Ok(arquivoprocessotemplate);
        }

        [HttpDelete]
        [Route("Deletar")]
        public async Task<IActionResult> Deletar([FromQuery] int id)
        {
            return Ok( new { mensagem = await _arquivoProcessoTemplateServico.Delete(id) });            
        }
    }
}
