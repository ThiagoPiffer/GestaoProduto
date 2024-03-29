﻿using GestaoProduto.Dados.Contextos;
using GestaoProduto.Dominio.Entity._Processo;
using GestaoProduto.Compartilhado.Model._GrupoProcesso;
using GestaoProduto.Compartilhado.Model._Processo;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._Processo;
using Microsoft.EntityFrameworkCore;
using GestaoProduto.Dados.Repositorio._RepositorioBase;

namespace GestaoProduto.Dados.Repositorio._Processo
{
    public class ProcessoRepositorio : RepositorioBase<Processo>, IProcessoRepositorio
    {
        public ProcessoRepositorio(ApplicationDbContext context) : base(context)
        {

        }

        public Task<List<Processo>> BuscaPorTermo(string termo)
        {
            var obj = Context.Set<Processo>().Where(a => a.Ativo && a.Descricao != null && a.Descricao.Contains(termo)).ToListAsync();
            return obj;
        }

        public async Task Armazenar(Processo processo)
        {
            try
            {
                await Context.AddAsync(processo);
                await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null) ex = ex.InnerException;
                Console.WriteLine(ex.Message);
            }

        }

        public void Update(Processo processo)
        {
            Context.Update(processo);
        }

        public async Task<List<GrupoProcessoModel>> ListarGrupoProcessoModel(int empresaId, bool exibeFinalizados = false)
        {
            var idsGrupos = await Context.GrupoProcesso.Where(o => o.EmpresaId == empresaId).Select(o => o.Id).ToListAsync();
            var grupoProcessos = await Context.Processo                
                .Include(p => p.GrupoProcesso) // Inclui os processos associados ao grupo
                .Where(p => idsGrupos.Contains(p.GrupoProcessoId) &&
                             ((exibeFinalizados && p.DataFinal.HasValue) || (!exibeFinalizados && !p.DataFinal.HasValue )) )
                                    
                .ToListAsync();

            var dataAtual = DateTime.Now;

            // Mapeia a lista de grupos para a lista de GrupoProcessoModel
            var listaGrupos = grupoProcessos.GroupBy(p => p.GrupoProcesso) // Agrupa os processos por Grupo
                            .Select(g => new GrupoProcessoModel
                            {
                                Id = g.Key.Id,
                                Nome = g.Key.Nome ?? string.Empty,
                                Posicao = g.Key.Posicao,
                                Ativo = g.Key.Ativo,
                                Processos = g.Select(p => new ProcessoModel
                                {
                                    Id = p.Id,
                                    Numero = p.Numero ?? string.Empty,
                                    Descricao = p.Descricao ?? string.Empty,
                                    //DataCadastro = p.DataCadastro.HasValue ? p.DataCadastro.Value.ToShortDateString() : null, // Se for nulo ou vazio retorna null
                                    DataInicio = p.DataInicio.HasValue ? p.DataInicio.Value.ToShortDateString() : null, // Se for nulo ou vazio retorna null
                                    Prazo = p.DataPrevista.HasValue ? (int?)p.DataPrevista.Value.Subtract(dataAtual).TotalDays : null,
                                    //Prazo = 0,
                                    DataPrevista = p.DataPrevista.HasValue ? p.DataPrevista.Value.ToShortDateString() : null, // Se for nulo ou vazio retorna null
                                    DataFinal = p.DataFinal.HasValue ? p.DataFinal.Value.ToShortDateString() : null, // Se for nulo ou vazio retorna null
                                    ValorCausa = p.ValorCausa ?? 0, // Se for nulo retorna 0
                                    Ativo = p.Ativo
                                }).ToList()
                            })
                            .ToList();


            return listaGrupos;
        }
    }
}
