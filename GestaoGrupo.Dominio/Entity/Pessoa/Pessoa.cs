using GestaoProduto.Dominio._Base;

namespace GestaoProduto.Dominio.Entity
{
    public class Pessoa : Entidade
    {
        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public int Idade { get; private set; }
        public string Email { get; private set; }
        public string CPFCNPJ { get; private set; }
        public string DDDTelefone { get; private set; }
        public string Telefone { get; private set; }
        public string DDDCelular { get; private set; }
        public string Celular { get; private set; }

        private Pessoa() { }

        public Pessoa(string nome, DateTime dataNascimento, int idade, string email, string cpfcnpj,
                        string dddTelefone, string telefone, string dddCelular, string celular, bool ativo)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Idade = idade;
            Email = email;
            CPFCNPJ = cpfcnpj;
            DDDTelefone = dddTelefone;
            Telefone = telefone;
            DDDTelefone = dddCelular;
            Celular = celular;
            Ativo = ativo;
        }

        //public void AlterarNome(string nome)
        //{
        //    ValidadorDeRegra.Novo()
        //        .Quando(nome == "", ChaveTextos.DescicaoProdutoVazio)
        //        .DispararExcecaoSeExistir();

        //    Nome = nome;
        //}

        //public void AlterarDataNascimento(DateTime dataNascimento)
        //{
        //    DataNascimento = dataNascimento;
        //}

        //public void AlterarDataValidade(Int32 idadde)
        //{
        //    Idade = idadde;
        //}

        //public void AlterarCPFCNPJ(string cnpfcnpj)
        //{
        //    ValidadorDeRegra.Novo()
        //        .Quando(string.IsNullOrEmpty(cnpfcnpj), ChaveTextos.CNPJFornecedorVazio)
        //        .Quando(ValidarCpfCnpj(cnpfcnpj), ChaveTextos.CNPJFornecedorIvalido)
        //        .DispararExcecaoSeExistir();

        //    CPFCNPJ = cnpfcnpj;
        //}

        //public void AlterarDDDTelefone(string dddTelefone)
        //{
        //    DDDTelefone = dddTelefone;
        //}
        //public void AlterarTelefone(string telefone)
        //{
        //    Telefone = telefone;
        //}

        //public void AlterarDDDCelular(string dddCelular)
        //{
        //    DDDCelular = dddCelular;
        //}

        //public void AlterarCelular(string celular)
        //{
        //    Celular = celular;
        //}

        //public void AlterarAtivo(bool ativo)
        //{
        //    Ativo = ativo;
        //}

        public static bool ValidarCpfCnpj(string cpfCnpj)
        {
            cpfCnpj = cpfCnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            if (cpfCnpj.Length == 11) // CPF
            {
                int[] multiplicadores = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                string cpfCalculado = "";
                int soma = 0;

                for (int i = 0; i < 9; i++)
                {
                    soma += int.Parse(cpfCnpj[i].ToString()) * multiplicadores[i];
                }

                int resto = soma % 11;
                if (resto < 2)
                {
                    cpfCalculado += "0";
                }
                else
                {
                    cpfCalculado += (11 - resto).ToString();
                }

                soma = 0;
                multiplicadores[0] = 11;
                multiplicadores[1] = 10;
                for (int i = 0; i < 10; i++)
                {
                    soma += int.Parse(cpfCnpj[i].ToString()) * multiplicadores[i];
                }

                resto = soma % 11;
                if (resto < 2)
                {
                    cpfCalculado += "0";
                }
                else
                {
                    cpfCalculado += (11 - resto).ToString();
                }

                return cpfCnpj.EndsWith(cpfCalculado);
            }
            else if (cpfCnpj.Length == 14) // CNPJ
            {
                int[] multiplicadores = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                string cnpjCalculado = "";
                int soma = 0;

                for (int i = 0; i < 12; i++)
                {
                    soma += int.Parse(cpfCnpj[i].ToString()) * multiplicadores[i];
                }

                int resto = soma % 11;
                if (resto < 2)
                {
                    cnpjCalculado += "0";
                }
                else
                {
                    cnpjCalculado += (11 - resto).ToString();
                }

                soma = 0;
                multiplicadores[0] = 6;
                multiplicadores[1] = 5;
                for (int i = 0; i < 13; i++)
                {
                    soma += int.Parse(cpfCnpj[i].ToString()) * multiplicadores[i];
                }

                resto = soma % 11;
                if (resto < 2)
                {
                    cnpjCalculado += "0";
                }
                else
                {
                    cnpjCalculado += (11 - resto).ToString();
                }

                return cpfCnpj.EndsWith(cnpjCalculado);
            }
            else // Caso contrário, não é válido
            {
                return false;
            }
        }
    }
}
