using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._Empresa;

namespace GestaoProduto.Dominio.Entity._Pessoa
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
        public int IdEmpresa { get; set; }

        //TIPOPESSOA
        //Cliente, Advogado de Defesa, Advogado de Acusação, Testemunha, Perito, Juiz, Júri, Réu, Queixoso/Reclamante, Terceiro Interessado, Fiador, Curador/Guardião ad Litem, Oficial de Justiça, Mediador, Árbitro, Transcritor/Court Reporter, Interveniente.



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
