using GestaoProduto.Dados.Contextos;
using GestaoProduto.Dados.Repositorio._RepositorioBase;
using GestaoProduto.Dominio.Entity._TipoPessoa;
using GestaoProduto.Dominio.Entity._Usuario;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._TipoPessoa;
using Microsoft.EntityFrameworkCore;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._Notificacao;

namespace GestaoProduto.Dados.Repositorio._Notificaao
{
    public class NotificacaoRepositorio : RepositorioBase<TipoPessoa>, INotificacaoRepositorio
    {
        public NotificacaoRepositorio(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<int> Quantidade(int empresaId)
        {
            var lista = await Context.Pessoa.Where(o => o.CadastroExterno && o.EmpresaId == empresaId).ToListAsync();
            return lista.Count();
        }
    }
}