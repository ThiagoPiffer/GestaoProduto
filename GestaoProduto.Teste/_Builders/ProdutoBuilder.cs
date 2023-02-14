using Bogus;
using GestaoProduto.Dominio.Produtos;
using GestaoProduto.Dominio.Fornecedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProduto.Teste._Builders
{
    public class ProdutoBuilder
    {
        protected int Id;
        protected Fornecedor Fornecedor;
        protected string Descricao;
        protected DateTime DataFabricacao;
        protected DateTime DataValidade;
        protected bool Ativo;

        public static ProdutoBuilder Novo()
        {
            var faker = new Faker();

            return new ProdutoBuilder
            {
                Fornecedor = FornecedorBuilder.Novo().Build(),
                Descricao = faker.Company.CompanyName(),
                DataFabricacao = faker.Date.Past(),
                DataValidade = faker.Date.Future(),
                Ativo = true
            };
        }

        public ProdutoBuilder ComDesrcicao(string descricao)
        {
            Descricao = descricao;
            return this;
        }

        public ProdutoBuilder ComDataFabricacao(DateTime dataFabricacao)
        {
            DataFabricacao = dataFabricacao;
            return this;
        }

        public ProdutoBuilder ComDataValidade(DateTime dataValidade)
        {
            DataValidade = dataValidade;
            return this;
        }

        public ProdutoBuilder ComId(int id)
        {
            Id = id;
            return this;
        }

        public Produto Build()
        {
            var produto = new Produto(Descricao, DataFabricacao, DataValidade, Fornecedor, Ativo);

            if (Id <= 0) return produto;

            var propertyInfo = produto.GetType().GetProperty("Id");
            propertyInfo.SetValue(produto, Convert.ChangeType(Id, propertyInfo.PropertyType), null);

            return produto;
        }
    }
}
