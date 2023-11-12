using GestaoProduto.Dominio.Entity._Usuario;
using GestaoProduto.Compartilhado.Model._Usuario;

namespace GestaoProduto.Compartilhado.Interfaces.Servico._Usuario
{
    public interface IUsuarioServico
    {
        Usuario UsuarioCurrent();
        Task<List<Usuario>> Listar();
        Task<UsuarioModel> ObterPorId(int id);        
        Task<List<Usuario>> BuscaPorTermo(string termo);
        Task<Usuario> Adicionar(UsuarioModel usuarioModel);
        Task<Usuario> Editar(UsuarioModel usuarioModel);
        Task<string> Delete(int id);        
    }
}
