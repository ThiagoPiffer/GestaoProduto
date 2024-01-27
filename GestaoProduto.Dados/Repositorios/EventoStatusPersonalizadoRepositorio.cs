using GestaoProduto.Dados.Contextos;
using GestaoProduto.Dados.Repositorio._RepositorioBase;
using GestaoProduto.Dominio.Entity._EventoStatusPersonalizado;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._EventoStatusPersonalizado;
using Microsoft.EntityFrameworkCore;
using GestaoProduto.Compartilhado.Model._Evento;
using GestaoProduto.Compartilhado.Model._EventoStatusPersonalizado;
using GestaoProduto.Dominio.Entity._Processo;
using GestaoProduto.Dominio.Entity._ProcessoStatusPersonalizado;
using System.Diagnostics;

namespace GestaoProduto.Dados.Repositorio._EventoStatusPersonalizado
{
    public class EventoStatusPersonalizadoRepositorio : RepositorioBase<EventoStatusPersonalizado>, IEventoStatusPersonalizadoRepositorio
    {
        public EventoStatusPersonalizadoRepositorio(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<EventoStatusPersonalizado> BuscarEventoStatus(int eventoId, int empresaId)
        {

            var evento = await Context.Evento.FirstOrDefaultAsync(o => o.Id == eventoId);

            var statusRetorno = new EventoStatusPersonalizado();
            if (evento != null)
            {
                if (evento.Encerrado)
                {
                    var status = new EventoStatusPersonalizado();
                    status.Nome = "Finalizado";
                    status.Descricao = "Evento finalizado";
                    status.Icone = "fas fa-check-circle";
                    status.Cor = "#000000";

                    return status;
                }


                var statusEvento = await Context.EventoStatusPersonalizado.Where(o => o.EmpresaId == empresaId).ToListAsync();
                var statusEventoMenor = statusEvento.Where(o => o.MenorQue).OrderByDescending(o => o.ValorControle).ToList();
                var statusEventoIgual = statusEvento.Where(o => o.IgualA).ToList();
                var statusEventoMaior = statusEvento.Where(o => o.MaiorQue).OrderBy(o => o.ValorControle).ToList();
                var dataAtual = DateTime.Now;

                foreach (var status in statusEventoMenor)
                {
                    var diferenca = dataAtual - evento.DataFinal;
                    if (diferenca.Days <= status.ValorControle)
                    {
                        statusRetorno = status;
                    }
                }

                foreach (var status in statusEventoIgual)
                {


                    var diferenca = dataAtual - evento.DataFinal;
                    if (diferenca.Days == status.ValorControle)
                    {
                        statusRetorno = status;
                    }
                }

                foreach (var status in statusEventoMaior)
                {
                    var diferenca = dataAtual - evento.DataFinal;
                    if (diferenca.Days >= status.ValorControle)
                    {
                        statusRetorno = status;
                    }
                }
            }

            return statusRetorno;
        }

        public async Task<List<EventoModel>> ListarEventos(int processoId, int empresaId, bool exibeEncerrados = false)
        {

            var listaEventos = Context.Evento
                .Where(o => o.EmpresaId == empresaId &&
                            o.ProcessoId == processoId &&
                             ((exibeEncerrados && o.Encerrado) || (!exibeEncerrados && !o.Encerrado))).ToListAsync();

            var listaEventosModel = new List<EventoModel>();
            foreach (var evento in listaEventos.Result)
            {
                var eventoModel = new EventoModel
                {
                    Id = evento.Id,
                    Nome = evento.Nome,
                    Descricao = evento.Descricao,
                    DataFinal = evento.DataFinal,
                    Encerrado = evento.Encerrado,
                    ProcessoId = evento.ProcessoId,
                    EmpresaId = evento.EmpresaId,
                    // Se você precisar de informações do Processo, você pode descomentar e ajustar a linha abaixo:
                    // Processo = new ProcessoModel { Id = evento.Processo.Id, Nome = evento.Processo.Nome },
                    // Se você precisar de informações da Empresa, você pode descomentar e ajustar a linha abaixo:
                    // Empresa = new EmpresaModel { Id = evento.Empresa.Id, Nome = evento.Empresa.Nome },
                };

                // Busca assíncrona do status personalizado do evento
                EventoStatusPersonalizado status = await BuscarEventoStatus(evento.Id, empresaId);
                eventoModel.EventoStatusPersonalizadoModel = new EventoStatusPersonalizadoModel
                {
                    Id = status.Id, // Presumo que a entidade tenha uma propriedade Id que não foi listada
                    Nome = status.Nome,
                    Descricao = status.Descricao,
                    MensagemNotificacao = status.MensagemNotificacao,
                    ValidaCondicao = status.ValidaCondicao,
                    MaiorQue = status.MaiorQue,
                    MenorQue = status.MenorQue,
                    IgualA = status.IgualA,
                    ValorControle = status.ValorControle,
                    Cor = status.Cor,
                    Icone = status.Icone,
                    EmpresaId = status.EmpresaId,
                    // Empresa = new EmpresaModel { ... } // Se necessário, mapeie a entidade Empresa para EmpresaModel
                };

                listaEventosModel.Add(eventoModel);
            }

            return listaEventosModel;
        }

    }
}