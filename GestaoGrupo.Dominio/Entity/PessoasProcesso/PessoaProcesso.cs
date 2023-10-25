using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._Processo;
using GestaoProduto.Dominio.Entity._Pessoa;
using GestaoProduto.Dominio.Entity._TipoPessoa;

namespace GestaoProduto.Dominio.Entity._PessoaProcesso
{
    public class PessoaProcesso : Entidade
    {
        public PessoaProcesso() { }
        public int ProcessoId { get; set; }
        public Processo Processo { get; set; }
        public int PessoaId { get; set; }     
        public Pessoa Pessoa { get; set; }
        public int? TipoPessoaId { get; set; }        
        public TipoPessoa TipoPessoa { get; set;}
    }

}
