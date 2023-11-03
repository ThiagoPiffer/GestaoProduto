using System.Collections.Generic;
using System.Threading.Tasks;
using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._Evento;

namespace GestaoProduto.Compartilhado.Interfaces.Repositorio._Evento
{
    public interface IEventoRepositorio : IRepositorio<Evento>
    {
        Task<List<Evento>> BuscaPorTermo(string termo);
        Task<Evento> BurcaPorId(int id);
        Task Armazenar(Evento evento);
        void Update(Evento evento);        
    }
}