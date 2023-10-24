using AutoMapper;
using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._TipoPessoaTemplate;
using GestaoProduto.Dominio.IRepositorio._Pessoa;
using GestaoProduto.Dominio.IRepositorio._TipoPessoaTemplateRepositorio;
using GestaoProduto.Dominio.IServico._TipoPessoaTemplateServico;
using GestaoProduto.Dominio.Model._PessoasProcesso;
using GestaoProduto.Dominio.Model._TipoPessoaTemplate;
using Microsoft.EntityFrameworkCore;


namespace GestaoProduto.Servico._TipoPessoaTemplate
{
    public class TipoPessoaTemplateServico : ITipoPessoaTemplateServico
    {
        private readonly IRepositorio<TipoPessoaTemplate> _repositorio;
        private readonly ITipoPessoaTemplateRepositorio _tipoPessoaTemplateRepositorio;
        private readonly IPessoaRepositorio _pessoaRepositorio;
        private readonly IMapper _mapper;

        public TipoPessoaTemplateServico(
            IRepositorio<TipoPessoaTemplate> repositorio,
            ITipoPessoaTemplateRepositorio tipoPessoaTemplateRepositorio,
            IPessoaRepositorio pessoaRepositorio,
            IMapper mapper
            )
        {
            _repositorio = repositorio;
            _tipoPessoaTemplateRepositorio = tipoPessoaTemplateRepositorio;
            _pessoaRepositorio=pessoaRepositorio;
            _mapper = mapper;
        }

        
        public async Task<List<TipoPessoaTemplate>> Listar()
        {
            var listaObj = await _repositorio.ObterListaAsync();
            var x = _mapper.Map<List<TipoPessoaTemplate>>(listaObj);
            return listaObj;
        }

        public async Task<TipoPessoaTemplateModel> ObterPorId(int id)
        {
            var Obj = await _repositorio.ObterPorIdAsync(id);
            var objModel = _mapper.Map<TipoPessoaTemplateModel>(Obj);

            return objModel;
        }

        public async Task<TipoPessoaTemplate> Adicionar(TipoPessoaTemplateModel model)
        {
            var obj = _mapper.Map<TipoPessoaTemplate>(model);
            await _repositorio.AdicionarAsync(obj);

            return obj;
        }

        public async Task<TipoPessoaTemplate> Editar(TipoPessoaTemplateModel model)
        {
            var obj = _mapper.Map<TipoPessoaTemplate>(model);
            await _repositorio.EditarAsync(obj);

            return obj;
        }

        public async Task<string> Delete(int id)
        {
            var obj = await _repositorio.ObterPorIdAsync(id);
            await _repositorio.ExcluirAsync(obj);

            return "Excluído com sucesso";
        }

        public async Task<List<TipoPessoaTemplate>> AdicionarTipoPessoaTemplate(List<TipoPessoaTemplateModel> model)
        {
            var obj = _mapper.Map<List<TipoPessoaTemplate>>(model);
            await _tipoPessoaTemplateRepositorio.AdicionarTipoPessoaTemplate(obj);

            return obj;
        }

        public async Task<List<PessoasProcessoModel>> ListarPessoaTemplate(int idArquivoTemplate, int idProcesso)
        {
            //busca tipos de pessoa do template
            var listaTiposPessoa = _repositorio.ObterListaFiltroAsync(t => t.IdArquivoProcessoTemplate == idArquivoTemplate && t.Ativo).Result.ToList();
            var listaIdsTiposPessoa = listaTiposPessoa.Select(l => l.IdTipoPessoa).ToList();
            var listaModel = _mapper.Map<List<TipoPessoaTemplateModel>>(listaTiposPessoa);

            var PessoasProcessoModel = await _pessoaRepositorio.ListarPessoasArquivoTemplate(idArquivoTemplate, idProcesso, listaIdsTiposPessoa);



            return PessoasProcessoModel;
        }

        public List<TipoPessoaTemplateModel> ListarTiposPessoaTemplate(int idProccessoTemplate)
        {
            return _tipoPessoaTemplateRepositorio.ListarTiposPessoaTemplate(idProccessoTemplate);
        }
    }
}
