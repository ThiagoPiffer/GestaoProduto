using GestaoProduto.Compartilhado.Model._Evento;
using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._EventoStatusPersonalizado;
using GestaoProduto.Dominio.Entity._ProcessoStatusPersonalizado;
using GestaoProduto.Dominio.Entity._TipoPessoa;

namespace GestaoProduto.Compartilhado.Interfaces.Repositorio._EventoStatusPersonalizado
{
    public interface IEventoStatusPersonalizadoRepositorio : IRepositorio<EventoStatusPersonalizado>
    {
        Task<EventoStatusPersonalizado> BuscarEventoStatus(int eventoId, int empresaId);
        Task<List<EventoModel>> ListarEventos(int processoId, int empresaId, bool exibeEncerrados = false);

    }
}