using AutoMapper;
using GestaoProduto.Dominio.Entity._Empresa;
using GestaoProduto.Compartilhado.Model._Empresa;

namespace GestaoProduto.Dados.Mapeamento
{
    public class EmpresaMapeamento : Profile
    {
        public EmpresaMapeamento()
        {
            CreateMap<EmpresaModel, Empresa>();
            CreateMap<Empresa, EmpresaModel>();
        }
    }
}
