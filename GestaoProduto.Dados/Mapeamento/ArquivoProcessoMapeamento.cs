using AutoMapper;
using GestaoProduto.Dominio.Entity;
using GestaoProduto.Dominio.Model;

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
