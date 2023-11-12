using GestaoProduto.Dominio.Entity._Evento;
using GestaoProduto.Compartilhado.Model._Evento;
using GestaoProduto.Dominio.Entity._ProcessoStatusPersonalizado;
using GestaoProduto.Dominio.Entity._EventoStatusPersonalizado;

namespace GestaoProduto.Compartilhado.Interfaces.Servico._Evento
{
    public interface IEventoServico
    {
        Task<List<EventoModel>> Listar(int processoId);
        Task<EventoStatusPersonalizado> BuscarEventoStatus(int eventoId);
        Task<EventoModel> ObterPorId(int id);
        Task<List<Evento>> BuscaPorTermo(string termo);
        Task<Evento> Adicionar(EventoModel eventoModel);
        Task<Evento> Editar(EventoModel eventoModel);
        Task<string> Delete(int id);        

    }
}