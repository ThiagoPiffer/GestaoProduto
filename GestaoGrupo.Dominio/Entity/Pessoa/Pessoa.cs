using GestaoProduto.Dominio._Base;

namespace GestaoProduto.Dominio.Entity
{
    public class Pessoa : Entidade
    {
        public Pessoa() { }

        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? Email { get; set; }
        public string CPFCNPJ { get; set; }
        public string Identidade { get; set; }
        public string? DDDTelefone { get; set; }
        public string? Telefone { get; set; }
        public string? DDDCelular { get; set; }
        public string? Celular { get; set; }

        //TIPOPESSOA
        //CLIENTE, TESTEMUNHA, TERCEIRO INTERESSADO

        /*
         * ---- CLIENTE
         *  ENDEREÇO
         *      NUMERO, RUA, BAIRRO, MUNIPIO, CIDADE, ESTADO, CEP
         *  NACIONALIDADE
         *  PROFISSAO
         *  ESTADI CIVIL
         *  
         *  ---- 
         * 
         * 
         */
    }
}
