using AutoMapper;
using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._Evento;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._Evento;
using GestaoProduto.Compartilhado.Interfaces.Servico._Evento;
using GestaoProduto.Compartilhado.Model._Evento;
using Newtonsoft.Json;
using GestaoProduto.Compartilhado.Interfaces._User;

namespace GestaoProduto.Servico._Evento
{
    public class EventoServico : IEventoServico
    {
        private readonly IRepositorio<Evento> _repositorio;
        private readonly IEventoRepositorio _eventoRepositorio;
        private readonly IMapper _mapper;
        private readonly IUser _user;

        public EventoServico(IRepositorio<Evento> repositorio,
                                        IEventoRepositorio eventoRepositorio,
                                        IMapper mapper,
                                        IUser user)
        {
            _repositorio = repositorio;
            _eventoRepositorio = eventoRepositorio;
            _mapper = mapper;
            _user = user;
        }

        public async Task<List<Evento>> Listar(int processoId)
        {
            var empresaId = _user.EmpresaCurrent.Id;
            var listaObj = await _repositorio
                .ObterListaFiltroAsync(o => o.EmpresaId == empresaId &&
                                                     o.ProcessoId == processoId);
            return listaObj;
        }

        public async Task<EventoModel> ObterPorId(int id)
        {
            var Obj = await _repositorio.ObterPorIdAsync(id);
            var objModel = _mapper.Map<EventoModel>(Obj);

            return objModel;
        }

        public async Task<List<Evento>> BuscaPorTermo(string termo)
        {
            List<Evento> lista = await _eventoRepositorio.BuscaPorTermo(termo);
            return lista;
        }

        public async Task<Evento> Adicionar(EventoModel model)
        {

            model.EmpresaId = _user.EmpresaCurrent.Id;
            var obj = _mapper.Map<Evento>(model);

            await _eventoRepositorio.AdicionarAsync(obj);

            return obj;
        }

        public async Task<Evento> Editar(EventoModel model)
        {
            var obj = _mapper.Map<Evento>(model);
            await _eventoRepositorio.EditarAsync(obj);

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