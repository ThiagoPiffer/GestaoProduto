using GestaoProduto.Compartilhado.Model._Empresa;
using GestaoProduto.Compartilhado.Model._Processo;

namespace GestaoProduto.Compartilhado.Model._Evento
{
    public class EventoModel
    {
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public DateTime DataFinal { get; set; }
        public int ProcessoId { get; set; }
        public virtual ProcessoModel? Processo { get; set; } = null;
        public int EmpresaId { get; set; }
        public virtual EmpresaModel? Empresa { get; set; } = null;
    }
}
