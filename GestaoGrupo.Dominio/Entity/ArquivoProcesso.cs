using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._Processo;

namespace GestaoProduto.Dominio.Entity._ArquivoProcesso
{
    public class ArquivoProcesso : Entidade
    {
        public ArquivoProcesso() { }

        public string NomeArquivo { get; set; }
        public string ExtensaoArquivo { get; set; }
        public string? Descricao { get; set; } // Uma descrição ou nota sobre o arquivo
        public int TamanhoArquivo { get; set; }
        public int ProcessoId { get; set; }
        public Processo Processo { get; set; }
        public string CaminhoArquivo { get; set; }
        //public string CaminhoArquivo { get; set; } 
        //public int UsuarioUploadId { get; set; } 
    }

}
