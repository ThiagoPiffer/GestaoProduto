using GestaoProduto.Dominio._Base;

namespace GestaoProduto.Dominio.Entity
{
    public class PessoasProcesso : Entidade
    {
        public int ProcessoId { get; set; }
        public Processo Processo { get; set; }

        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }

        public int? TipoPessoaProcessoId { get; set; }
        public TipoPessoaProcesso? TipoPessoaProcesso { get; set; }

        public PessoasProcesso() { }
    }

}
