using GestaoProduto.Dominio._Base;

namespace GestaoProduto.Dominio.Entity
{
    public class ObjetoCustomizado : Entidade
    {
        public ObjetoCustomizado() { }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public string DataCadastro { get; set; }
        public TipoStatusObjeto Status { get; set; }
        public string Anotacao { get; set; }
        public byte[] Arquivo { get; set; }
    }
}
