using Bogus;
using GestaoProduto.Teste._Builders;
using GestaoProduto.Dominio.Produtos;
using ExpectedObjects;
using GestaoProduto.Teste._Util;
using Xunit;
using GestaoProduto.Dominio._Base;

namespace GestaoProduto.Teste.Produtos
{
    public class ProdutoTeste
    {
        private readonly Faker _faker;

        public ProdutoTeste()
        {
            _faker = new Faker();
        }

        [Fact]
        public void DeveCriarProduto()
        {
            var fornecedor = FornecedorBuilder.Novo().Build();
            var produtoEsperado = new
            {
                Ativo = true,
                Descricao = _faker.Commerce.Product(),
                DataFabricacao = _faker.Date.Past(),
                DataValidade = _faker.Date.Future(),
                Fornecedor = fornecedor,
            };

            var produto = new Produto(produtoEsperado.Descricao,
                                      produtoEsperado.DataFabricacao,
                                      produtoEsperado.DataValidade,
                                      produtoEsperado.Fornecedor,
                                      produtoEsperado.Ativo);

            produtoEsperado.ToExpectedObject().ShouldMatch(produto);
        }

        [Fact]
        public void deveAlterarDescricao()
        {
            var novaDescricaoEsperado = _faker.Commerce.Product();
            var produto = ProdutoBuilder.Novo().Build();

            produto.AlterarDescricao(novaDescricaoEsperado);

            Assert.Equal(novaDescricaoEsperado, produto.Descricao);
        }

        [Fact]
        public void deveAlterarDataFabricacao()
        {
            var novaDataFabricacaoEsperado = _faker.Date.Past();
            var produto = ProdutoBuilder.Novo().ComDataValidade(DateTime.Now).Build();

            produto.AlterarDataFabricacao(novaDataFabricacaoEsperado);

            Assert.Equal(novaDataFabricacaoEsperado, produto.DataFabricacao);
        }

        [Fact]
        public void ErroDataFabricacaoMaiorQueDataValidade()
        {            
            var produto = ProdutoBuilder.Novo().ComDataValidade(DateTime.Now).Build();

            produto.AlterarDataFabricacao(DateTime.Now.AddDays(1));            

            Assert.Throws<ExcecaoDeDominio>(() =>
                   produto.AlterarDataFabricacao(DateTime.Now.AddDays(1)))
               .ComMensagem(ChaveTextos.DataFabricacaoMaiorQueDataValidade);
        }

        [Fact]
        public void deveAlterarDataValidade()
        {
            var novaDataValidadeEsperado = _faker.Date.Future();
            var produto = ProdutoBuilder.Novo().ComDataFabricacao(DateTime.Now).Build();

            produto.AlterarDataValidade(novaDataValidadeEsperado);

            Assert.Equal(novaDataValidadeEsperado, produto.DataValidade);
        }

        [Fact]
        public void ErroDataValidadeMenorQueDataFabricacao()
        {            
            var produto = ProdutoBuilder.Novo().ComDataFabricacao(DateTime.Now).Build();

            produto.AlterarDataValidade(DateTime.Now.AddDays(-1));

            Assert.Throws<ExcecaoDeDominio>(() =>
                   produto.AlterarDataFabricacao(DateTime.Now.AddDays(-1)))
               .ComMensagem(ChaveTextos.DataFabricacaoMaiorQueDataValidade);
        }



    }
}
