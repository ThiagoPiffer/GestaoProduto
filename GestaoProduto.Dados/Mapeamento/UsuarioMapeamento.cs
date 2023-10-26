using AutoMapper;
using GestaoProduto.Dominio.Entity._Usuario;
using GestaoProduto.Dominio.Model._Usuario;

namespace GestaoProduto.Dados.Mapeamento
{
    public class UsuarioMapeamento : Profile
    {
        public UsuarioMapeamento() 
        {
            CreateMap<UsuarioModel, Usuario>();
            CreateMap<Usuario, UsuarioModel>();
        }
    }
}
