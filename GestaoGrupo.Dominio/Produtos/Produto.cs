using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Fornecedores;


namespace GestaoProduto.Dominio.Produtos
{
    public class Produto : Entidade
    {
        public string Descricao { get; private set; }
        public DateTime DataFabricacao { get; private set; }
        public DateTime DataValidade { get; private set; }
        public Fornecedor Fornecedor { get; private set; }

        private Produto() { }

        public Produto(string descricao, DateTime dataFabricacao, DateTime dataValidade, Fornecedor fornecedor, bool ativo)
        { 
            Descricao = descricao;
            DataFabricacao = dataFabricacao;
            DataValidade = dataValidade;
            Fornecedor = fornecedor;
            Ativo = ativo;
        }

        public void AlterarDescricao(string descricao)
        {
            ValidadorDeRegra.Novo()
                .Quando(descricao == "", ChaveTextos.DescicaoProdutoVazio)
                .DispararExcecaoSeExistir();

            Descricao = descricao;
        }

        public void AlterarDataFabricacao(DateTime dataFabricacao)
        {
            ValidadorDeRegra.Novo()
                .Quando(DataFabricacao >= DataValidade, ChaveTextos.DataFabricacaoMaiorQueDataValidade)
                .DispararExcecaoSeExistir();

            DataFabricacao = dataFabricacao;
        }

        public void AlterarDataValidade(DateTime dataValidade)
        {
            ValidadorDeRegra.Novo()
                .Quando(DataValidade <= DataFabricacao, ChaveTextos.DataValidadeMenorQueDataFabricacao)
                .DispararExcecaoSeExistir();

            DataValidade = dataValidade;
        }

        public void AlterarFornecedor(Fornecedor fornecedor)
        {
            ValidadorDeRegra.Novo()
                .Quando(fornecedor == null, ChaveTextos.FornecedorObrigatorio)
                .DispararExcecaoSeExistir();

            Fornecedor = fornecedor;
        }

        public void AlterarAtivo(bool ativo)
        {           
            Ativo = ativo;
        }
    }
}
