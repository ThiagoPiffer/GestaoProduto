using GestaoProduto.Compartilhado.Interfaces.Servico._IdentidadeCurrent;
using GestaoProduto.Dominio.Entity._Usuario;
using GestaoProduto.Dominio.Entity._Empresa;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._IdentidadeCurrent;

namespace GestaoProduto.Servico._IdentidadeCurrent
{
    public class IdentidadeCurrentServico : IIdentidadeCurrentServico
    {        
        private readonly IIdentidadeCurrentRepositorio _identidadeCurrentRepositorio;

        public IdentidadeCurrentServico(IIdentidadeCurrentRepositorio identidadeCurrentRepositorio)
        {
            _identidadeCurrentRepositorio=identidadeCurrentRepositorio;
        }       

        public async Task<Usuario> ObterUsuarioCurrentAsync(Guid idAspNetUser)
        {
            return await _identidadeCurrentRepositorio.ObterUsuarioCurrentAsync(idAspNetUser);
        }
        //public async Task<Empresa> ObterEmpresaCurrentAsync(Guid idAspNetUser)
        //{
        //    return await _identidadeCurrentRepositorio.ObterEmpresaCurrentAsync(idAspNetUser);
        //}
    }
}
