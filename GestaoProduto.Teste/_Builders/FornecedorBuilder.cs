using Bogus;
using Bogus.DataSets;
using Bogus.Extensions.Brazil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestaoProduto.Dominio.Fornecedores;

namespace GestaoProduto.Teste._Builders
{
    public class FornecedorBuilder
    {
        protected int Id;
        protected string Descricao;
        protected string CNPJ;
        protected bool Ativo;

        public static FornecedorBuilder Novo()
        {
            var faker = new Faker();

            return new FornecedorBuilder
            {
                Descricao = faker.Company.CompanyName(),
                CNPJ = faker.Company.Cnpj(),                
                Ativo = true
            };
        }

        public FornecedorBuilder ComDesrcicao(string descricao)
        {
            Descricao = descricao;
            return this;
        }

        public FornecedorBuilder ComCNPJ(string cnpj)
        {
            CNPJ = cnpj;
            return this;
        }

        public FornecedorBuilder ComId(int id)
        {
            Id = id;
            return this;
        }

        public Fornecedor Build()
        {
            var fornecedor = new Fornecedor(Descricao, CNPJ, Ativo);

            if (Id <= 0) return fornecedor;

            var propertyInfo = fornecedor.GetType().GetProperty("Id");
            propertyInfo.SetValue(fornecedor, Convert.ChangeType(Id, propertyInfo.PropertyType), null);

            return fornecedor;
        }
    }
}
