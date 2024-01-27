using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProduto.Compartilhado._ConfiguracaoTemplateModel
{
    public class PessoaConfiguracao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string DataNascimento { get; set; } // Considere usar DateTime se a data for necessária.
        public int? Idade { get; set; } // Nullable, já que parece que pode ser null
        public string Email { get; set; }
        public string Cpfcnpj { get; set; }
        public string Identidade { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string TipoPessoaDescricao { get; set; }
        public string Profissao { get; set; }
        public string Nacionalidade { get; set; }
        public string EstadoCivil { get; set; }
        public string Numero { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Municipio { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public bool Ativo { get; set; }
    }

    public class TipoConfiguracao
    {
        public int IdTipoPessoa { get; set; }
        public int IdArquivoProcessoTemplate { get; set; }
        public string CampoChave { get; set; }
        public int Id { get; set; }
        public bool Ativo { get; set; }
        public string DataCadastro { get; set; } // Considere usar DateTime se a data for necessária.
    }

    public class ConfiguracaoTemplateModel
    {
        public Dictionary<int, PessoaConfiguracao> ListaPessoa { get; set; }
        public List<TipoConfiguracao> ListaTipos { get; set; }
        public int IdArquivoTemplate { get; set; }
    }
}
