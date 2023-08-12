namespace GestaoProduto.Dominio.Model
{
    public class GrupoProcessoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Posicao { get; set; }
        public bool Ativo { get; set; }

        public List<ProcessoModel> Processos { get; set; } = new List<ProcessoModel>();
        public GrupoProcessoModel()
        {
            Processos = new List<ProcessoModel>();
        }
    }
}
