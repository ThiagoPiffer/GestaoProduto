using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._ControlePessoaExterna;
using GestaoProduto.Dominio.Entity._Empresa;
using GestaoProduto.Dominio.Entity._Endereco;

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
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public int? EnderecoId { get; set; }
        public Endereco? Endereco { get; set; }
        public string? Nacionalidade { get; set; }
        public string? Profissao { get; set; }
        public string? EstadoCivil { get; set; }
        public bool CadastroExterno { get; set; } = false;
        public int? ControlePessoaExternaId { get; set; }
        public ControlePessoaExterna ControlePessoaExterna { get; set; }


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
