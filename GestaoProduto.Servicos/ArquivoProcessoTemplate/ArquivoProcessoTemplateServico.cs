using GestaoProduto.Dominio.Entity._ArquivoProcessoTemplate;
using GestaoProduto.Dominio.Entity._TipoPessoaTemplate;
using GestaoProduto.Dominio.Model._TipoPessoaTemplate;
using GestaoProduto.Dominio.IServico._ArquivoProcessoTemplate;
using GestaoProduto.Dominio.Model._ArquivoProcessoTemplate;
using GestaoProduto.Dominio.IRepositorio._ArquivoProcessoTemplate;
using GestaoProduto.Dominio._Base;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GestaoProduto.Dominio.IRepositorio._TipoPessoaTemplateRepositorio;
using GestaoProduto.Dados.Repositorio._ArquivoProcessoTemplateRepositorio;

namespace GestaoProduto.Servico._ArquivoProcessoTemplate
{
    public class ArquivoProcessoTemplateServico : IArquivoProcessoTemplateServico
    {
        private readonly IRepositorio<ArquivoProcessoTemplate> _repositorio;        
        private readonly IArquivoProcessoTemplateRepositorio _arquivoProcessoTemplateRepositorio;
        private readonly IMapper _mapper;

        public ArquivoProcessoTemplateServico(
            IRepositorio<ArquivoProcessoTemplate> repositorio,
            IArquivoProcessoTemplateRepositorio arquivoProcessoTemplateRepositorio,            
            IMapper mapper)
        {
            _repositorio = repositorio;
            _arquivoProcessoTemplateRepositorio = arquivoProcessoTemplateRepositorio;            
            _mapper = mapper;
        }

        public async Task<List<ArquivoProcessoTemplate>> Listar()
        {
            var listaObj = await _repositorio.ObterListaAsync();
            var x = _mapper.Map<List<ArquivoProcessoTemplate>>(listaObj);
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

        public async Task<ArquivoProcessoTemplate> Adicionar(int idProcesso, int idEmpresa, IFormFile file)
        {
            var idUsuario = 1;
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
            obj.idEmpresa = idEmpresa;

            // Salve o arquivo
            using (var arquivo = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
            {
                await file.CopyToAsync(arquivo);
            }

            await _repositorio.AdicionarAsync(obj);

            //List<TipoPessoaTemplate> entidades = _mapper.Map<List<TipoPessoaTemplate>>(tiposPessoa);
            //await _repositorioPessoaTemplate.AdicionarListaAsync(entidades);

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
