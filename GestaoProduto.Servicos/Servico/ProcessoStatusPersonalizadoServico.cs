using AutoMapper;
using GestaoProduto.Dominio._Base;
using GestaoProduto.Compartilhado.Model._ProcessoStatusPersonalizado;
using GestaoProduto.Compartilhado.Interfaces._User;
using GestaoProduto.Compartilhado.Interfaces.Servico._ProcessoStatusPersonalizado;
using GestaoProduto.Dominio.Entity._ProcessoStatusPersonalizado;

namespace GestaoProduto.Servico._ProcessoStatusPersonalizado
{
    public class ProcessoStatusPersonalizadoServico : IProcessoStatusPersonalizadoServico
    {
        private readonly IRepositorio<ProcessoStatusPersonalizado> _repositorio;
        private readonly IMapper _mapper;
        private readonly IUser _user;

        public ProcessoStatusPersonalizadoServico(IRepositorio<ProcessoStatusPersonalizado> repositorio,
                                        IMapper mapper,
                                        IUser user)
        {
            _repositorio = repositorio;
            _mapper = mapper;
            _user = user;
        }   
        
        public async Task<List<ProcessoStatusPersonalizado>> Listar()
        {
            var empresa = _user.EmpresaCurrent;
            var lista = await _repositorio.ObterListaFiltroAsync(o => o.EmpresaId == empresa.Id); 
            return lista.ToList();
        }

        public async Task<ProcessoStatusPersonalizadoModel> ObterPorId(int id)
        {
            var Obj = await _repositorio.ObterPorIdAsync(id);
            var objModel = _mapper.Map<ProcessoStatusPersonalizadoModel>(Obj);

            return objModel;
        }

        public async Task<ProcessoStatusPersonalizado> Adicionar(ProcessoStatusPersonalizadoModel model)
        {
            var empresaId = _user.EmpresaCurrent.Id;
            model.EmpresaId = empresaId;

            var obj = _mapper.Map<ProcessoStatusPersonalizado>(model);
            await _repositorio.AdicionarAsync(obj);

            return obj;
        }        

        public async Task<ProcessoStatusPersonalizado> Editar(ProcessoStatusPersonalizadoModel model)
        {
            var obj = _mapper.Map<ProcessoStatusPersonalizado>(model);
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