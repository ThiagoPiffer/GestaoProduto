using GestaoProduto.Dados.Contextos;
using GestaoProduto.Dados.Repositorio._RepositorioBase;
using GestaoProduto.Dominio.Entity._ProcessoStatusPersonalizado;
using GestaoProduto.Dominio.Entity._Usuario;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._ProcessoStatusPersonalizado;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace GestaoProduto.Dados.Repositorio._ProcessoStatusPersonalizado
{
    public class ProcessoStatusPersonalizadoRepositorio : RepositorioBase<ProcessoStatusPersonalizado>, IProcessoStatusPersonalizadoRepositorio
    {
        public ProcessoStatusPersonalizadoRepositorio(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<ProcessoStatusPersonalizado> BuscarProcessoStatus(int processoId, int empresaId)
        {
            var processo = await Context.Processo.FirstOrDefaultAsync(o => o.Id == processoId);
            var statusRetorno = new ProcessoStatusPersonalizado();
            if (processo != null)
            {
                var statusProcesso = await Context.ProcessoStatusPersonalizado.Where(o => o.EmpresaId == empresaId).ToListAsync();                
                var statusProcessoMenor = statusProcesso.Where(o => o.MenorQue).OrderByDescending(o => o.ValorControle).ToList();
                var statusProcessoIgual = statusProcesso.Where(o => o.IgualA).ToList();
                var statusProcessoMaior = statusProcesso.Where(o => o.MaiorQue).OrderBy(o => o.ValorControle).ToList();
                var dataAtual = DateTime.Now;

                foreach (var status in statusProcessoMenor)
                {
                    if (processo.DataPrevista.HasValue)
                    {
                        var diferenca = dataAtual - processo.DataPrevista.Value;
                        if (diferenca.Days <= status.ValorControle)
                        {
                            statusRetorno = status;
                        }
                    }
                }

                foreach (var status in statusProcessoIgual)
                {
                    if (processo.DataPrevista.HasValue)
                    {
                        var diferenca = dataAtual - processo.DataPrevista.Value;
                        if (diferenca.Days == status.ValorControle)
                        {
                            statusRetorno = status;
                        }
                    }
                }

                foreach (var status in statusProcessoMaior)
                {
                    if (processo.DataPrevista.HasValue)
                    {
                        var diferenca = dataAtual - processo.DataPrevista.Value;
                        if (diferenca.Days >= status.ValorControle)
                        {
                            statusRetorno = status;
                        }
                    }
                }
            }
            return statusRetorno;
        }

    }
}