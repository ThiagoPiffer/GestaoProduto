using AutoMapper;
using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._TipoPessoa;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._TipoPessoa;
using GestaoProduto.Compartilhado.Interfaces.Servico._TipoPessoa;
using GestaoProduto.Compartilhado.Model._TipoPessoa;
using GestaoProduto.Compartilhado.Interfaces._User;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._Processo;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._Pessoa;
using GestaoProduto.Dominio.Entity._Empresa;
using GestaoProduto.Dominio.Entity._PessoaProcesso;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._PessoaProcesso;

namespace GestaoProduto.Servico._TipoPessoa
{
    public class TipoPessoaServico : ITipoPessoaServico
    {
        private readonly IRepositorio<TipoPessoa> _repositorio;
        private readonly ITipoPessoaRepositorio _tipoPessoaRepositorio;
        private readonly IProcessoRepositorio _processoRepositorio;
        private readonly IPessoaRepositorio _pessoaRepositorio;
        private readonly IPessoaProcessoRepositorio _pessoaProcessoRepositorio;
        private readonly IMapper _mapper;
        private readonly IUser _user;

        public TipoPessoaServico(IRepositorio<TipoPessoa> repositorio,
                                        ITipoPessoaRepositorio tipoPessoaRepositorio,
                                        IProcessoRepositorio processoRepositorio,
                                        IPessoaRepositorio pessoaRepositorio,
                                        IPessoaProcessoRepositorio pessoaProcessoRepositorio,
                                        IMapper mapper,
                                        IUser user)
        {
            _repositorio = repositorio;
            _tipoPessoaRepositorio = tipoPessoaRepositorio;
            _processoRepositorio = processoRepositorio;
            _pessoaRepositorio=pessoaRepositorio;
            _pessoaProcessoRepositorio=pessoaProcessoRepositorio;
            _mapper = mapper;
            _user = user;
        }

        public async Task<List<TipoPessoa>> Listar()
        {
            var listaObj = await _repositorio.ObterListaAsync();
            return listaObj;
        }

        public async Task<List<TipoPessoa>> listarTipoPessoasCompleta()
        {
            var empresaId = _user.EmpresaCurrent.Id;
            var listaObj = await _repositorio
                .ObterListaFiltroAsync(o => o.EmpresaId == empresaId);
            return listaObj;
        }

        public async Task<List<TipoPessoa>> listarTipoPessoasProcesso(int processoId)
        {
            var empresaId = _user.EmpresaCurrent.Id;
            var pessoasProcesso = await _pessoaRepositorio.ListarPessoasProcesso(processoId,empresaId,true,false);
            var idsTiposPessoaProcesso = pessoasProcesso.Select(o => o.idTipoPessoa).ToList();
            //var processo = await _processoRepositorio.ObterPorIdAsync(processoId);

            var listaTipoPessoaProcesso = await _repositorio
                .ObterListaFiltroAsync(o => o.EmpresaId == empresaId &&
                                                     !idsTiposPessoaProcesso.Contains(o.Id));

            return listaTipoPessoaProcesso;
        }
        

        public async Task<TipoPessoaModel> ObterPorId(int id)
        {
            var Obj = await _repositorio.ObterPorIdAsync(id);
            var objModel = _mapper.Map<TipoPessoaModel>(Obj);

            return objModel;
        }

        public async Task<List<TipoPessoa>> BuscaPorTermo(string termo)
        {
            List<TipoPessoa> lista = await _tipoPessoaRepositorio.BuscaPorTermo(termo);
            return lista;
        }

        public async Task<TipoPessoa> Adicionar(TipoPessoaModel model)
        {
            var empresaId = _user.EmpresaCurrent.Id;
            model.EmpresaId = empresaId;

            var obj = _mapper.Map<TipoPessoa>(model);
            await _tipoPessoaRepositorio.AdicionarAsync(obj);

            return obj;
        }

        public async Task<PessoaProcesso> Associar(TipoPessoaModel model, int processoId, int pessoaId)
        {
            var empresaId = _user.EmpresaCurrent.Id;
            var processo = await _processoRepositorio.ObterPorIdAsync(processoId);
            var pessoa = await _pessoaRepositorio.ObterPorIdAsync(pessoaId);

            var result = _pessoaProcessoRepositorio
                .ObterListaFiltroAsync(o => o.ProcessoId == processoId &&
                                                     o.PessoaId == pessoaId).Result;

            var pessoaProcesso = result != null && result.Count() > 0 ? result[0] : null;
            if (pessoaProcesso != null)
            {
                pessoaProcesso.TipoPessoaId = model.Id;
                await _pessoaProcessoRepositorio.EditarAsync(pessoaProcesso);
                return pessoaProcesso;
            }
            else
            {
                new ExcecaoDeDominio(new List<string> { "Pessoa não associada no processp" });
                return null;
            }
        }

        public async Task<TipoPessoa> Editar(TipoPessoaModel model)
        {
            var obj = _mapper.Map<TipoPessoa>(model);
            await _tipoPessoaRepositorio.EditarAsync(obj);

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