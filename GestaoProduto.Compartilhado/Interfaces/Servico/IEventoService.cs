using GestaoProduto.Dominio.Entity._Evento;
using GestaoProduto.Compartilhado.Model._Evento;

namespace GestaoProduto.Compartilhado.Interfaces.Servico._Evento
{
    public interface IEventoServico
    {
        Task<List<Evento>> Listar(int processoId);
        Task<EventoModel> ObterPorId(int id);
        Task<List<Evento>> BuscaPorTermo(string termo);
        Task<Evento> Adicionar(EventoModel eventoModel);
        Task<Evento> Editar(EventoModel eventoModel);
        Task<string> Delete(int id);        

    }
}