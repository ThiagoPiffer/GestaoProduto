using AutoMapper;
using GestaoProduto.Dominio.Entity;
using GestaoProduto.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProduto.Dados.Mapeamento
{
    public class GrupoProcessoMapeamento : Profile
    {
        public GrupoProcessoMapeamento()
        {
            CreateMap<GrupoProcesso, GrupoProcessoDto>()
            .ReverseMap();

        }
    }
}
