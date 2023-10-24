using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._ArquivoProcessoTemplate;
using GestaoProduto.Dominio.Model._ArquivoProcessoTemplate;
using GestaoProduto.Dominio.IServico._ArquivoProcessoTemplate;
using GestaoProduto.Dominio.IServico._Pessoa;
using GestaoProduto.Dominio.IServico._TipoPessoaTemplateServico;
using Microsoft.AspNetCore.Mvc;
using Xceed.Document.NET;
using Xceed.Words.NET;
using GestaoProduto.Dominio.Model._TipoPessoaTemplate;
using GestaoProduto.Dominio.Entity._TipoPessoaTemplate;
using GestaoProduto.Servico._TipoPessoaTemplate;
using GestaoProduto.Dominio.Model.RequestModel;
using GestaoProduto.Dominio.Model._PessoasProcesso;
using System;
using System.Reflection.Metadata;

namespace GestaoProduto.API.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<IActionResult> Adicionar([FromQuery] int idProcesso, int idEmpresa, [FromForm] IFormFile file)
        {            
            ArquivoProcessoTemplate arquivoprocessotemplate = await _arquivoProcessoTemplateServico.Adicionar(idProcesso, idEmpresa, file);


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

        public class Pessoa
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string DataNascimento { get; set; } // Considere usar DateTime se a data for necessária.
            public int? Idade { get; set; } // Nullable, já que parece que pode ser null
            public string Email { get; set; }
            public string Cpfcnpj { get; set; }
            public string Identidade { get; set; }
            public string DddTelefone { get; set; }
            public string Telefone { get; set; }
            public string DddCelular { get; set; }
            public string Celular { get; set; }
            public string TipoPessoaDescricao { get; set; }
            public bool Ativo { get; set; }
        }

        public class Tipo
        {
            public int IdTipoPessoa { get; set; }
            public int IdArquivoProcessoTemplate { get; set; }
            public string CampoChave { get; set; }
            public int Id { get; set; }
            public bool Ativo { get; set; }
            public string DataCadastro { get; set; } // Considere usar DateTime se a data for necessária.
        }

        public class ConfiguracaoTemplateModel
        {
            public Dictionary<int, Pessoa> ListaPessoa { get; set; }
            public List<Tipo> ListaTipos { get; set; }
            public int IdArquivoTemplate { get; set; }
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

                    var chave = configuracaoTemplate.ListaTipos.First(l => l.Id == pessoa.Key).CampoChave;

                    // Use o método ReplaceText com o objeto StringReplaceTextOptions
                    document.ReplaceText("{{nome" + chave + "}}", pessoa.Value.Nome ?? "");
                    document.ReplaceText("{{cpf" + chave + "}}", pessoa.Value.Cpfcnpj);
                    document.ReplaceText("{{email" + chave + "}}", pessoa.Value.Email);
                    document.ReplaceText("{{identidade" + chave + "}}", pessoa.Value.Identidade);
                    document.ReplaceText("{{dataNascimento" + chave + "}}", pessoa.Value.DataNascimento);
                    document.ReplaceText("{{telefone" + chave + "}}", pessoa.Value.Telefone);
                    document.ReplaceText("{{celular" + chave + "}}", pessoa.Value.Celular);
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
        public Task<List<PessoasProcessoModel>> ListarPessoaTemplate(int idArquivoTemplate, int idProcesso)
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
