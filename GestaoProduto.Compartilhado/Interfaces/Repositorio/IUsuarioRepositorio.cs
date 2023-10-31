
using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._Usuario;

namespace GestaoProduto.Compartilhado.Interfaces.Repositorio._Usuario
{    
    public interface IUsuarioRepositorio : IRepositorio<Usuario>
    {
        Task<List<Usuario>> BuscaPorTermo(string termo);
        Task Armazenar(Usuario usuario);
        void Update(Usuario usuario);
        string BuscaIdUsuarioAspNet(string email);
        void DeletarIdUsuarioAspNet(string id);

    }
}
