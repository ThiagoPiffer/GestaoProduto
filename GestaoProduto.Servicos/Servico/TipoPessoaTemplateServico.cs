using AutoMapper;
using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._TipoPessoaTemplate;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._Pessoa;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._TipoPessoaTemplateRepositorio;
using GestaoProduto.Compartilhado.Interfaces.Servico._TipoPessoaTemplateServico;
using GestaoProduto.Compartilhado.Model._PessoaProcesso;
using GestaoProduto.Dominio.Model._TipoPessoaTemplate;
using Microsoft.EntityFrameworkCore;
using GestaoProduto.Compartilhado.Interfaces._User;

namespace GestaoProduto.Servico._TipoPessoaTemplate
{
    public class TipoPessoaTemplateServico : ITipoPessoaTemplateServico
    {
        private readonly IRepositorio<TipoPessoaTemplate> _repositorio;
        private readonly ITipoPessoaTemplateRepositorio _tipoPessoaTemplateRepositorio;
        private readonly IPessoaRepositorio _pessoaRepositorio;
        private readonly IMapper _mapper;
        private readonly IUser _user;

        public TipoPessoaTemplateServico(
            IRepositorio<TipoPessoaTemplate> repositorio,
            ITipoPessoaTemplateRepositorio tipoPessoaTemplateRepositorio,
            IPessoaRepositorio pessoaRepositorio,
            IMapper mapper,
            IUser user
            )
        {
            _repositorio = repositorio;
            _tipoPessoaTemplateRepositorio = tipoPessoaTemplateRepositorio;
            _pessoaRepositorio=pessoaRepositorio;
            _mapper = mapper;
            _user = user;
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

        public async Task<List<PessoaProcessoModel>> ListarPessoaTemplate(int idArquivoTemplate, int idProcesso)
        {
            var empresa = _user.EmpresaCurrent;
            //busca tipos de pessoa do template
            var listaTiposPessoaTemplate = _repositorio.ObterListaFiltroAsync(t => t.ArquivoProcessoTemplateId == idArquivoTemplate && t.Ativo).Result.ToList();
            var listaIdsTiposPessoa = listaTiposPessoaTemplate.Select(l => l.TipoPessoaId).ToList();            
            var empresaId = _user.EmpresaCurrent.Id;

            var PessoasProcessoModel = await _pessoaRepositorio.ListarPessoasArquivoTemplate(idArquivoTemplate, idProcesso, empresaId, listaIdsTiposPessoa);



            return PessoasProcessoModel;
        }

        public List<TipoPessoaTemplateModel> ListarTiposPessoaTemplate(int idProccessoTemplate)
        {
            return _tipoPessoaTemplateRepositorio.ListarTiposPessoaTemplate(idProccessoTemplate);
        }
    }
}
