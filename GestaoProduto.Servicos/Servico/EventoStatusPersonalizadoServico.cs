using AutoMapper;
using GestaoProduto.Dominio._Base;
using GestaoProduto.Compartilhado.Model._EventoStatusPersonalizado;
using GestaoProduto.Compartilhado.Interfaces._User;
using GestaoProduto.Compartilhado.Interfaces.Servico._EventoStatusPersonalizado;
using GestaoProduto.Dominio.Entity._ProcessoStatusPersonalizado;

namespace GestaoProduto.Servico._EventoStatusPersonalizado
{
    public class EventoStatusPersonalizadoServico : IEventoStatusPersonalizadoServico
    {
        private readonly IRepositorio<EventoStatusPersonalizado> _repositorio;
        private readonly IMapper _mapper;
        private readonly IUser _user;

        public EventoStatusPersonalizadoServico(IRepositorio<EventoStatusPersonalizado> repositorio,
                                        IMapper mapper,
                                        IUser user)
        {
            _repositorio = repositorio;
            _mapper = mapper;
            _user = user;
        }   
        
        public async Task<List<EventoStatusPersonalizado>> Listar()
        {
            var empresa = _user.EmpresaCurrent;
            var lista = await _repositorio.ObterListaFiltroAsync(o => o.EmpresaId == empresa.Id); 
            return lista.ToList();
        }

        public async Task<EventoStatusPersonalizadoModel> ObterPorId(int id)
        {
            var Obj = await _repositorio.ObterPorIdAsync(id);
            var objModel = _mapper.Map<EventoStatusPersonalizadoModel>(Obj);

            return objModel;
        }

        public async Task<EventoStatusPersonalizado> Adicionar(EventoStatusPersonalizadoModel model)
        {
            var empresaId = _user.EmpresaCurrent.Id;
            model.EmpresaId = empresaId;

            var obj = _mapper.Map<EventoStatusPersonalizado>(model);
            await _repositorio.AdicionarAsync(obj);

            return obj;
        }        

        public async Task<EventoStatusPersonalizado> Editar(EventoStatusPersonalizadoModel model)
        {
            var obj = _mapper.Map<EventoStatusPersonalizado>(model);
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