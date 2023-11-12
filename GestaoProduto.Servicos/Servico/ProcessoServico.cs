using GestaoProduto.Dominio._Base;
using AutoMapper;
using GestaoProduto.Dominio.Entity._Processo;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._Processo;
using GestaoProduto.Compartilhado.Interfaces.Servico._Processo;
using GestaoProduto.Compartilhado.Model._Processo;
using GestaoProduto.Dominio.Entity._ProcessoStatusPersonalizado;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._ProcessoStatusPersonalizado;
using GestaoProduto.Compartilhado.Interfaces._User;

namespace GestaoProduto.Servico._Processo
{
    public class ProcessoServico : IProcessoServico
    {
        private readonly IRepositorio<Processo> _repositorio;
        private readonly IProcessoRepositorio _processoRepositorio;
        private readonly IProcessoStatusPersonalizadoRepositorio _processoStatusPersonalizadoRepositorio;
        private readonly IMapper _mapper;
        private readonly IUser _user;

        public ProcessoServico(IRepositorio<Processo> repositorio,
                                        IProcessoRepositorio processoRepositorio,
                                        IProcessoStatusPersonalizadoRepositorio processoStatusPersonalizadoRepositorio,
                                        IMapper mapper,
                                        IUser user)
        {
            _repositorio = repositorio;
            _processoRepositorio = processoRepositorio;
            _processoStatusPersonalizadoRepositorio = processoStatusPersonalizadoRepositorio;
            _mapper = mapper;
            _user=user;
        }

        public async Task<ProcessoStatusPersonalizado> BuscarProcessoStatus(int processoId)
        {
            var empresaId = _user.EmpresaCurrent.Id;
            var status = await _processoStatusPersonalizadoRepositorio.BuscarProcessoStatus(processoId, empresaId);
            return status;
        }


        public async Task<List<Processo>> Listar()
        {
            var listaProcessos = await _repositorio.ObterListaAsync();
            return listaProcessos;
        }

        public async Task<ProcessoModel> ObterPorId(int id)
        {
            var processo = await _repositorio.ObterPorIdAsync(id);
            var processoModel = _mapper.Map<ProcessoModel>(processo);
            
            return processoModel;
        }

        public async Task<List<Processo>> BuscaPorTermo(string termo)
        {
            List<Processo> processos = await _processoRepositorio.BuscaPorTermo(termo);            
            return processos;
        }

        public async Task<Processo> Adicionar(ProcessoModel processoModel)
        {            
            var processo = _mapper.Map<Processo>(processoModel);                
            await _processoRepositorio.AdicionarAsync(processo);

            return processo;
        }

        public async Task<Processo> Editar(ProcessoModel processoModel)
        {
            var empresaId = _user.EmpresaCurrent.Id;
            processoModel.EmpresaId = empresaId;
            var processo = _mapper.Map<Processo>(processoModel);
            await _processoRepositorio.EditarAsync(processo);

            return processo;
        }

        public async Task<string> Delete(int id)
        {
            var obj = await _repositorio.ObterPorIdAsync(id);
            await _repositorio.ExcluirAsync(obj);

            return "Excluído com sucesso";
        }
    }
}
