using GestaoProduto.Compartilhado.Model._EventoStatusPersonalizado;
using GestaoProduto.Dominio.Entity._EventoStatusPersonalizado;
using GestaoProduto.Dominio.Entity._ProcessoStatusPersonalizado;

namespace GestaoProduto.Compartilhado.Interfaces.Servico._EventoStatusPersonalizado
{
    public interface IEventoStatusPersonalizadoServico
    {
        Task<List<EventoStatusPersonalizado>> Listar();
        Task<EventoStatusPersonalizadoModel> ObterPorId(int id);
        Task<EventoStatusPersonalizado> Adicionar(EventoStatusPersonalizadoModel eventoStatusPersonalizadoModel);
        Task AdicionarStatusPadraoEvento();
        Task<EventoStatusPersonalizado> Editar(EventoStatusPersonalizadoModel eventoStatusPersonalizadoModel);
        Task<string> Delete(int id);
    }
}