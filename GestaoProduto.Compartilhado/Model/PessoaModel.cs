using GestaoProduto.Compartilhado.Model._ControlePessoaExterna;
using GestaoProduto.Compartilhado.Model._Empresa;
using GestaoProduto.Compartilhado.Model._Endereco;

namespace GestaoProduto.Compartilhado.Model._Pessoa
{
    public class PessoaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string DataNascimento { get; set; } = string.Empty;
        public int Idade { get; set; }
        public string Email { get; set; } = string.Empty;
        public string CPFCNPJ { get; set; } = string.Empty;
        public string Identidade { get; set; } = string.Empty;
        public string DDDTelefone { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string DDDCelular { get; set; } = string.Empty;
        public string Celular { get; set; } = string.Empty;
        public bool Ativo { get; set; }
        public int EmpresaId { get; set; }
        public EmpresaModel Empresa { get; set; }
        public int? EnderecoId { get; set; }
        public EnderecoModel? Endereco { get; set; }
        public string? Nacionalidade { get; set; }
        public string? Profissao { get; set; }
        public string? EstadoCivil { get; set; }
        public bool CadastroExterno { get; set; } = false;
        public int? ControlePessoaExternaId { get; set; }
        public ControlePessoaExternaModel ControlePessoaExterna { get; set; }
    }
}
