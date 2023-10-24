using GestaoProduto.Dominio.Entity._Usuario;
using GestaoProduto.Dominio.Model._Usuario;

namespace GestaoProduto.Dominio.IServico._Usuario
{
    public interface IUsuarioServico
    {
        Task<List<Usuario>> Listar();
        Task<UsuarioModel> ObterPorId(int id);
        Task<List<Usuario>> BuscaPorTermo(string termo);
        Task<Usuario> Adicionar(UsuarioModel usuarioModel);
        Task<Usuario> Editar(UsuarioModel usuarioModel);
        Task<string> Delete(int id);
    }
}
