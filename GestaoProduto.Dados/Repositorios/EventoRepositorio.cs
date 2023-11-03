using GestaoProduto.Dados.Contextos;
using GestaoProduto.Dados.Repositorio._RepositorioBase;
using GestaoProduto.Dominio.Entity._Evento;
using GestaoProduto.Dominio.Entity._Usuario;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._Evento;
using Microsoft.EntityFrameworkCore;

namespace GestaoProduto.Dados.Repositorio._Evento
{
    public class EventoRepositorio : RepositorioBase<Evento>, IEventoRepositorio
    {
        public EventoRepositorio(ApplicationDbContext context) : base(context)
        {

        }

        public Task<List<Evento>> BuscaPorTermo(string termo)
        {
            var obj = Context.Set<Evento>().Where(a => a.Ativo && a.Descricao != null && a.Descricao.Contains(termo)).ToListAsync();
            return obj;
        }

        public async Task<Evento> BurcaPorId(int id)
        {
            var obj = await Context.Set<Evento>().FirstOrDefaultAsync(a => a.Ativo && a.Id == id);
            return obj;
        }


        public async Task Armazenar(Evento evento)
        {
            try
            {
                await Context.AddAsync(evento);
                await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null) ex = ex.InnerException;
                Console.WriteLine(ex.Message);
            }

        }

        public void Update(Evento evento)
        {
            Context.Update(evento);
        }
    }
}