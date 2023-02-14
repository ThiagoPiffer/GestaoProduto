using Bogus;
using Bogus.DataSets;
using Bogus.Extensions.Brazil;
using ExpectedObjects;
using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Fornecedores;
using GestaoProduto.Teste._Util;
using GestaoProduto.Dominio.Produtos;
using GestaoProduto.Teste._Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;

namespace GestaoProduto.Teste.Fornecedores
{
    public class FornecedorTeste
    {
        private readonly Faker _faker;
        private readonly FornecedorDto _fornecedorDto;
        private readonly ArmazenadorFornecedor _armazenadorFornecedor;
        private readonly Mock<IFornecedorRepositorio> _fornecedorRepositorio;

        public FornecedorTeste()
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
        public void DeveCriarFornecedor()
        {            
            var fornecedorEsperado = new
            {
                Ativo = true,
                Descricao = _faker.Company.CompanyName(),
                CNPJ = _faker.Company.Cnpj()
            };

            var fornecedor = new Fornecedor(fornecedorEsperado.Descricao,
                                            fornecedorEsperado.CNPJ,
                                            fornecedorEsperado.Ativo);

            fornecedorEsperado.ToExpectedObject().ShouldMatch(fornecedor);
        }

        [Fact]
        public void deveAlterarDescricao()
        {
            //Arrange
            var novaDescricaoEsperado = _faker.Company.CompanyName();
            var fornecedor = FornecedorBuilder.Novo().Build();
            //Action
            fornecedor.AlterarDescricao(novaDescricaoEsperado);
            //Assert
            Assert.Equal(novaDescricaoEsperado, fornecedor.Descricao);
        }

        [Fact]
        public void deveAlterarCNPJ()
        {
            var novoCNPJEsperado = _faker.Company.Cnpj();
            var fornecedor = FornecedorBuilder.Novo().Build();

            fornecedor.AlterarCNPJ(novoCNPJEsperado);

            Assert.Equal(novoCNPJEsperado, fornecedor.CNPJ);
        }

        [Theory]
        [InlineData("")]        
        public void ErroCNPJVazio(string cnpj)
        {            
            var fornecedor = FornecedorBuilder.Novo().Build();
            
            Assert.Throws<ExcecaoDeDominio>(() =>
                fornecedor.AlterarCNPJ(cnpj))
                .ComMensagem(ChaveTextos.CNPJFornecedorVazio);
        }

        [Theory]        
        [InlineData("58.842.481/0001-61")]// CNPJ invalido, para CNPJ correto trocar o ultimo carcter para 2
        public void ErroCNPJInvalido(string cnpj)
        {
            var fornecedor = FornecedorBuilder.Novo().Build();

            Assert.Throws<ExcecaoDeDominio>(() =>
                fornecedor.AlterarCNPJ(cnpj))
                .ComMensagem(ChaveTextos.CNPJFornecedorIvalido);
        }
    }
}
