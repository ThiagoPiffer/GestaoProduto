using GestaoProduto.Dominio._Base;

namespace GestaoProduto.Dominio.Entity
{
    public class ObjetoCustomizado : Entidade
    {        
        public string Descricao { get; set; } = string.Empty;
        public TipoStatusObjeto Status { get; set; } 
        public string Anotacao { get; set; } = string.Empty;
        public byte[] Arquivo { get; set; } = new byte[0];
    }
}
