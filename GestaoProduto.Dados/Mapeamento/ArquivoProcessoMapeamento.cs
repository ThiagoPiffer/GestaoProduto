using AutoMapper;
using GestaoProduto.Dominio.Entity._ArquivoProcesso;
using GestaoProduto.Dominio.Model._ArquivoProcesso;

namespace GestaoProduto.Dados.Mapeamento
{
    public class ArquivoProcessoMapeamento : Profile
    {
        public ArquivoProcessoMapeamento()
        {
            // Mapeando ArquivoProcesso para ArquivoProcessoModel
            CreateMap<ArquivoProcesso, ArquivoProcessoModel>()
                .ReverseMap();           
        }
    }
}
