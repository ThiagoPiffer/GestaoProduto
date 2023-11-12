namespace GestaoProduto.Compartilhado.Model._Processo
{
    public class ProcessoModel
    {
        public int Id { get; set; }
        public string? Numero { get; set; } = string.Empty;
        public string? Descricao { get; set; } = string.Empty;
        public string? DataInicio { get; set; } = string.Empty;
        public int? Prazo { get; set; } = 0;
        public string? DataPrevista { get; set; } = string.Empty;
        public string? DataFinal { get; set; } = string.Empty;
        public Double? ValorCausa { get; set; } = 0;
        public int GrupoProcessoId { get; set; }
        public bool Ativo { get; set; }
        public int EmpresaId { get; set; }
    }
}