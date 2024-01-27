using AutoMapper;
using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._Evento;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._Evento;
using GestaoProduto.Compartilhado.Interfaces.Servico._Evento;
using GestaoProduto.Compartilhado.Model._Evento;
using Newtonsoft.Json;
using GestaoProduto.Compartilhado.Interfaces._User;
using GestaoProduto.Dominio.Entity._EventoStatusPersonalizado;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._EventoStatusPersonalizado;
using System.Collections.Generic;
using GestaoProduto.Compartilhado.Model._Processo;
using GestaoProduto.Dominio.Entity._Processo;

namespace GestaoProduto.Servico._Evento
{
    public class EventoServico : IEventoServico
    {
        private readonly IRepositorio<Evento> _repositorio;
        private readonly IEventoRepositorio _eventoRepositorio;
        private readonly IEventoStatusPersonalizadoRepositorio _eventoStatusPersonalizadoRepositorio;
        private readonly IMapper _mapper;
        private readonly IUser _user;

        public EventoServico(IRepositorio<Evento> repositorio,
                                        IEventoRepositorio eventoRepositorio,
                                        IEventoStatusPersonalizadoRepositorio eventoStatusPersonalizadoRepositorio,
                                        IMapper mapper,
                                        IUser user)
        {
            _repositorio = repositorio;
            _eventoRepositorio = eventoRepositorio;
            _eventoStatusPersonalizadoRepositorio= eventoStatusPersonalizadoRepositorio;
            _mapper = mapper;
            _user = user;
        }

        public async Task<EventoStatusPersonalizado> BuscarEventoStatus(int eventoId)
        {
            var empresaId = _user.EmpresaCurrent.Id;
            var status = await _eventoStatusPersonalizadoRepositorio.BuscarEventoStatus(eventoId, empresaId);
            return status;
        }

        public async Task<List<EventoModel>> Listar(int processoId, bool exibeEncerrados = false)
        {
            var empresaId = _user.EmpresaCurrent.Id;
            return await _eventoStatusPersonalizadoRepositorio.ListarEventos(processoId, empresaId, exibeEncerrados);
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

        public async Task<Evento> ReabrirEvento(EventoModel eventoModel)
        {
            var empresaId = _user.EmpresaCurrent.Id;
            eventoModel.EmpresaId = empresaId;            
            eventoModel.Encerrado = false;
            var evento = _mapper.Map<Evento>(eventoModel);
            await _eventoRepositorio.EditarAsync(evento);

            return evento;
        }

        public async Task<Evento> FinalizarEvento(EventoModel eventoModel)
        {
            var empresaId = _user.EmpresaCurrent.Id;
            eventoModel.EmpresaId = empresaId;
            eventoModel.Encerrado = true;
            var evento = _mapper.Map<Evento>(eventoModel);
            await _eventoRepositorio.EditarAsync(evento);

            return evento;
        }

        public async Task<string> Delete(int id)
        {
            var obj = await _repositorio.ObterPorIdAsync(id);
            await _repositorio.ExcluirAsync(obj);

            return "Excluído com sucesso";
        }
    }
}