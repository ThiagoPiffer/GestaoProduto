using GestaoProduto.Dominio._Base;

namespace GestaoProduto.Dominio.Entity
{
    public class ProcessoDto 
    {
        public int Id { get; set; }
        public string Numero { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string DataCadastro { get; set; } = string.Empty;
        public string DataInicio { get; set; } = string.Empty;
        public string DataPrevista { get; set; } = string.Empty;
        public string DataFinal { get; set; } = string.Empty;        
        public double ValorCausa { get; set; }
        public Boolean Ativo { get; set; }

    }
}

