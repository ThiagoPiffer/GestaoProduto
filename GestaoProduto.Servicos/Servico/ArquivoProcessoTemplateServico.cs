using GestaoProduto.Dominio.Entity._ArquivoProcessoTemplate;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._ArquivoProcessoTemplate;
using GestaoProduto.Compartilhado.Model._ArquivoProcessoTemplate;
using GestaoProduto.Dominio._Base;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using GestaoProduto.Compartilhado.Interfaces.Servico._ArquivoProcessoTemplate;
using GestaoProduto.Compartilhado.Interfaces._User;
using GestaoProduto.Dominio.Model._TipoPessoaTemplate;
using GestaoProduto.Compartilhado.Interfaces.Servico._TipoPessoaTemplateServico;

namespace GestaoProduto.Servico._ArquivoProcessoTemplate
{
    public class ArquivoProcessoTemplateServico : IArquivoProcessoTemplateServico
    {
        private readonly IRepositorio<ArquivoProcessoTemplate> _repositorio;        
        private readonly IArquivoProcessoTemplateRepositorio _arquivoProcessoTemplateRepositorio;
        private readonly ITipoPessoaTemplateServico _tipoPessoaTemplateServico;
        private readonly IUser _user;
        private readonly IMapper _mapper;

        public ArquivoProcessoTemplateServico(
            IRepositorio<ArquivoProcessoTemplate> repositorio,
            IArquivoProcessoTemplateRepositorio arquivoProcessoTemplateRepositorio,
            ITipoPessoaTemplateServico tipoPessoaTemplateServico,
            IUser user,
            IMapper mapper)
        {
            _repositorio = repositorio;
            _arquivoProcessoTemplateRepositorio = arquivoProcessoTemplateRepositorio;   
            _tipoPessoaTemplateServico = tipoPessoaTemplateServico;
            _user = user;
            _mapper = mapper;
        }

        public async Task<List<ArquivoProcessoTemplate>> Listar()
        {
            var empresa = _user.EmpresaCurrent;
            var listaObj = await _repositorio.
                ObterListaFiltroAsync(o => o.EmpresaId == empresa.Id);

            return listaObj;
        }

        public async Task<ArquivoProcessoTemplate> ObterPorId(int id)
        {
            var obj = await _repositorio.ObterPorIdAsync(id);            
            return obj;
        }

        public async Task<List<ArquivoProcessoTemplate>> BuscaPorTermo(string termo)
        {
            List<ArquivoProcessoTemplate> lista = await _arquivoProcessoTemplateRepositorio.BuscaPorTermo(termo);
            return lista;
        }

        public async Task<ArquivoProcessoTemplate> Adicionar(int idProcesso, IFormFile file, List<TipoPessoaTemplateModel> tiposPessoaTemplate)
        {
            var usuario = _user.UsuarioCurrent;
            var idUsuario = usuario.Id;
            var idEmpresa = usuario.EmpresaId;
            foreach (var tipos in tiposPessoaTemplate)
                tipos.EmpresaId = idEmpresa;

            string pathBase = Path.Combine("Arquivos\\Templates", $"folderEmpresa_{idEmpresa}", $"folderUsuario_{idUsuario}", $"folderProcesso_{idProcesso}");

            // Verifique se o diretório existe; se não, crie-o
            if (!Directory.Exists(pathBase))
            {
                Directory.CreateDirectory(pathBase);
            }            

            //cria objeto
            ArquivoProcessoTemplate obj = new ArquivoProcessoTemplate();
            obj.Nome = file.FileName;

            string fullPath = Path.Combine(pathBase, obj.Nome);
            obj.CaminhoArquivo = fullPath;
            obj.TamanhoArquivo = file.Length > 0 ? file.Length : 0;
            obj.EmpresaId = idEmpresa;

            // Salve o arquivo
            using (var arquivo = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
            {
                await file.CopyToAsync(arquivo);
            }

            await _repositorio.AdicionarAsync(obj);

            foreach (var tipos in tiposPessoaTemplate)
            {
                tipos.EmpresaId = idEmpresa;
                tipos.ArquivoProcessoTemplateId = obj.Id;
            }

            await _tipoPessoaTemplateServico.AdicionarTipoPessoaTemplate(tiposPessoaTemplate);

            return obj;
        }

        public async Task<ArquivoProcessoTemplate> Editar(ArquivoProcessoTemplateModel model)
        {
            var obj = _mapper.Map<ArquivoProcessoTemplate>(model);
            await _repositorio.EditarAsync(obj);

            return obj;
        }

        public async Task<string> Delete(int id)
        {
            var obj = await _repositorio.ObterPorIdAsync(id);
            await _repositorio.ExcluirAsync(obj);

            return "Excluído com sucesso";
        }
    }
}
