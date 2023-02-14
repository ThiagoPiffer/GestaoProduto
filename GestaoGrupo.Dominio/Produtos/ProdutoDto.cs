using GestaoProduto.Dominio.Fornecedores;

namespace GestaoProduto.Dominio.Produtos
{
    public class ProdutoDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public Boolean Ativo { get; set; }
    }
}
