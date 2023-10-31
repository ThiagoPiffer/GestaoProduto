namespace GestaoProduto.Compartilhado.Model._TipoPessoa
{
    public class TipoPessoaModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public int EmpresaId { get; set; }
    }
}
