﻿using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._Empresa;
using GestaoProduto.Dominio.Entity._GrupoProcesso;

namespace GestaoProduto.Compartilhado.Interfaces.Repositorio._GrupoProcesso
{
    public interface IGrupoProcessoRepositorio : IRepositorio<GrupoProcesso>
    {
        Task Armazenar(GrupoProcesso grupoProcesso);
        Task<List<GrupoProcesso>> ObterListaCustomizadaAsync();
    }
}
