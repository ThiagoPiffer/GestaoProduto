using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestaoProduto.Dominio._Base;

namespace GestaoProduto.Dominio.Fornecedores
{
    public class Fornecedor : Entidade
    {
        public string Descricao { get; private set; }
        public string CNPJ { get; private set; }


        private Fornecedor() { }

        public Fornecedor(string descricao, string cnpj, bool ativo, int id = 0)
        {
            ValidadorDeRegra.Novo()
                .Quando(string.IsNullOrEmpty(descricao), ChaveTextos.DescricaoFornecedorVazio)
                .Quando(string.IsNullOrEmpty(cnpj), ChaveTextos.CNPJFornecedorVazio)
                .Quando(CNPJValido(cnpj), ChaveTextos.CNPJFornecedorIvalido)
                .DispararExcecaoSeExistir();


            Descricao = descricao;
            CNPJ = cnpj;
            Ativo = ativo;
        }

        public void AlterarDescricao(string descricao)
        {
            ValidadorDeRegra.Novo()
                .Quando(string.IsNullOrEmpty(descricao), ChaveTextos.DescricaoFornecedorVazio)
                .DispararExcecaoSeExistir();

            Descricao = descricao;
        }

        public void AlterarCNPJ(string cnpj)
        {
            ValidadorDeRegra.Novo()                
                .Quando(string.IsNullOrEmpty(cnpj), ChaveTextos.CNPJFornecedorVazio)
                .Quando(CNPJValido(cnpj), ChaveTextos.CNPJFornecedorIvalido)
                .DispararExcecaoSeExistir();

            CNPJ = cnpj;
        }

        static bool CNPJValido(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;

            string tempCnpj = cnpj.Substring(0, 12);
            int soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            int resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            if (cnpj.EndsWith(digito))
                return false;
            else
                return true;
        }
        public void AlterarAtivo(bool ativo)
        {
            Ativo = ativo;
        }
    }
}
