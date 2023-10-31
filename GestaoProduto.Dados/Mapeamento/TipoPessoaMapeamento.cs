using AutoMapper;
using GestaoProduto.Compartilhado.Model._TipoPessoa;
using GestaoProduto.Dominio.Entity._TipoPessoa;

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
