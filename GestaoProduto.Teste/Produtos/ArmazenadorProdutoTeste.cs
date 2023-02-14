using Bogus;
using Bogus.Extensions.Brazil;
using GestaoProduto.Dominio.Fornecedores;
using GestaoProduto.Dominio.Produtos;
using GestaoProduto.Teste._Builders;
using Moq;
using Xunit;

namespace GestaoProduto.Teste.Produtos
{
    public class ArmazenadorProdutoTeste
    {
        private readonly Faker _faker;
        private readonly ProdutoDto _produtoDto;
        private readonly FornecedorDto _fornecedorDto;
        private readonly ArmazenadorProduto _armazenadorProduto;
        private readonly ArmazenadorFornecedor _armazenadorFornecedor;        
        private readonly Mock<IProdutoRepositorio> _produtoRepositorioMock;
        private readonly Mock<IFornecedorRepositorio> _fornecedorRepositorioMock;        

        public ArmazenadorProdutoTeste()
        {
            _faker = new Faker();
            var fornecedor = FornecedorBuilder.Novo().Build();
            _fornecedorDto = new FornecedorDto
            {
                Descricao = _faker.Company.CompanyName(),
                CNPJ = _faker.Company.Cnpj(),
                Ativo = true
            };


            _produtoDto = new ProdutoDto
            {
                Ativo = true,
                Descricao = _faker.Commerce.Product(),
                DataFabricacao = _faker.Date.Past(),
                DataValidade = _faker.Date.Future(),
                Fornecedor = fornecedor,
            };

            _produtoRepositorioMock = new Mock<IProdutoRepositorio>();
            _fornecedorRepositorioMock = new Mock<IFornecedorRepositorio>();
            _armazenadorProduto = new ArmazenadorProduto(_produtoRepositorioMock.Object, _fornecedorRepositorioMock.Object);
            _armazenadorFornecedor = new ArmazenadorFornecedor(_fornecedorRepositorioMock.Object);
        }

        [Fact]
        public void DeveAdicionarProduto()
        {
            _armazenadorProduto.Armazenar(_produtoDto);

            _produtoRepositorioMock.Verify(r => r.Adicionar(
                It.Is<Produto>(
                    c => c.Descricao == _produtoDto.Descricao                    
                )
            ));

        }
    }
}
