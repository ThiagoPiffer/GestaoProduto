namespace GestaoProduto.Dominio._Base
{
    public static class ChaveTextos
    {
        //Produto
        public static string DescicaoProdutoVazio = "Descrição do Produto Vazio";
        public static string DescricaoFornecedorVazio = "Descrição do Fornecedor Vazio";
        public static string CNPJFornecedorVazio = "CNPJ do Fornecedor Vazio";
        public static string CNPJFornecedorIvalido = "CNPJ do Fornecedor Inválido";
        public static string DataFabricacaoMaiorQueDataValidade = "Data Fabricação deve ser menor que a Data Validade";
        public static string DataValidadeMenorQueDataFabricacao = "Data Validade deve ser Maior que a Data Fabricação";
        public static string CNPJJaCadastrado = "CNPJ já cadastrado";
        public static string CNPJInexistente = "CNPJ não existe na base de dados";
        public static string ProdutoJaCadastrado = "Produto já cadastrado";
        public static string FornecedorObrigatorio = "Fornecedor é um campo obrigatório";

        //Pessoa
        public static string DescicaoPessoaVazio = "Descrição do Pessoa Vazio";
        public static string PessoaCNPJJaCadastrado = "CPF/CNPJ já cadastrado";
        public static string PessoaEmailJaCadastrado = "Email já cadastrado";
    }
}
