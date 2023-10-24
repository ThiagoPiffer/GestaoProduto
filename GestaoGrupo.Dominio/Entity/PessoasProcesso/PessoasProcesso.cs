using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._Processo;
using GestaoProduto.Dominio.Entity._Pessoa;
using GestaoProduto.Dominio.Entity._TipoPessoa;

namespace GestaoProduto.Dominio.Entity._PessoasProcesso
{
    public class PessoasProcesso : Entidade
    {
        public PessoasProcesso() { }
        public int ProcessoId { get; set; }
        public int PessoaId { get; set; }        
        public int? TipoPessoaId { get; set; }        
    }

}
