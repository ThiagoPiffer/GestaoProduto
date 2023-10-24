using AutoMapper;
using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._TipoPessoa;
using GestaoProduto.Dominio.Entity._TipoPessoaTemplate;
using GestaoProduto.Dominio.IRepositorio._TipoPessoa;
using GestaoProduto.Dominio.Model._TipoPessoaTemplate;

namespace GestaoProduto.Dados.Mapeamento
{
    public class TipoPessoaTemplateMapeamento : Profile
    {
        public TipoPessoaTemplateMapeamento() 
        {
            CreateMap<TipoPessoaTemplateModel, TipoPessoaTemplate>();
            CreateMap<TipoPessoaTemplate, TipoPessoaTemplateModel>();
        }
    }
}
