using GestaoProduto.Dominio.Entity._Evento;
using GestaoProduto.Compartilhado.Model._Evento;
using GestaoProduto.Dominio.Entity._ProcessoStatusPersonalizado;
using GestaoProduto.Dominio.Entity._EventoStatusPersonalizado;
using GestaoProduto.Compartilhado.Model._Processo;
using GestaoProduto.Dominio.Entity._Processo;

namespace GestaoProduto.Compartilhado.Interfaces.Servico._Evento
{
    public interface IEventoServico
    {
        Task<List<EventoModel>> Listar(int processoId, bool exibeEncerrados = false);
        Task<EventoStatusPersonalizado> BuscarEventoStatus(int eventoId);
        Task<EventoModel> ObterPorId(int id);
        Task<List<Evento>> BuscaPorTermo(string termo);
        Task<Evento> Adicionar(EventoModel eventoModel);
        Task<Evento> Editar(EventoModel eventoModel);
        Task<Evento> ReabrirEvento(EventoModel eventoModel);
        Task<Evento> FinalizarEvento(EventoModel eventoModel);
        Task<string> Delete(int id);        

    }
}