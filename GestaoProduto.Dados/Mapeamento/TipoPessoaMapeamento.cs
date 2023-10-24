using AutoMapper;
using GestaoProduto.Dominio.Entity._Empresa;
using GestaoProduto.Dominio.Entity._TipoPessoa;
using GestaoProduto.Dominio.Entity._TipoPessoaTemplate;
using GestaoProduto.Dominio.Model._TipoPessoa;
using GestaoProduto.Dominio.Model._TipoPessoaTemplate;

namespace GestaoProduto.Dados.Mapeamento
{
    public class TipoPessoaMapeamento : Profile
    {
        public TipoPessoaMapeamento()
        {
            CreateMap<TipoPessoaModel, TipoPessoa>();
            CreateMap<TipoPessoa, TipoPessoaModel>();

        }
    }
}
