using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._Empresa;
using GestaoProduto.Dominio.Entity._Processo;

namespace GestaoProduto.Dominio.Entity._Evento
{
    public class Evento : Entidade
    {
        public Evento() { }

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime  DataFinal { get; set; }
        public int ProcessoId { get; set; }
        public virtual Processo Processo { get; set; }
        public int EmpresaId { get; set; }
        public virtual Empresa  Empresa { get; set; }
    }
}
