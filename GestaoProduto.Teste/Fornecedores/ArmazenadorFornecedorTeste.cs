using Bogus;
using Bogus.Extensions.Brazil;
using GestaoProduto.Dominio.Fornecedores;
using Moq;
using Xunit;

namespace GestaoProduto.Teste.Fornecedores
{
    public class ArmazenadorProdutoTeste
    {
        private readonly Faker _faker;
        private readonly FornecedorDto _fornecedorDto;
        private readonly ArmazenadorFornecedor _armazenadorFornecedor;
        private readonly Mock<IFornecedorRepositorio> _fornecedorRepositorio;

        public ArmazenadorProdutoTeste()
        {
            _faker = new Faker();
            _fornecedorDto = new FornecedorDto
            {
                Descricao = _faker.Company.CompanyName(),
                CNPJ = _faker.Company.Cnpj(),
                Ativo = true
            };
            _fornecedorRepositorio = new Mock<IFornecedorRepositorio>();
            _armazenadorFornecedor = new ArmazenadorFornecedor(_fornecedorRepositorio.Object);
        }

        [Fact]
        public void DeveAdicionarFornecedor()
        {
            _armazenadorFornecedor.Armazenar(_fornecedorDto);

            _fornecedorRepositorio.Verify(r => r.Adicionar(It.Is<Fornecedor>(a => a.Descricao == _fornecedorDto.Descricao)));
        }     
    }
}
