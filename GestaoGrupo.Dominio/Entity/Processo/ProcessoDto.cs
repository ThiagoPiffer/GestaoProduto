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



        // incluir pessoas: Uma breve descrição do caso e dos problemas legais envolvidos.
        // incluir advogados: envolvidos Os advogados que estão representando as partes no processo.
        //incluir Fases do processo: 
        /*
            string[] fasesDoProcesso = {
            "Fase de Consulta/Análise do Caso",
            "Fase de Pré-Processual (ou Pré-Contenciosa)",
            "Protocolo da Petição Inicial",
            "Citação e Intimação",
            "Contestação",
            "Fase de Instrução",
            "Audiências",
            "Alegações Finais",
            "Sentença",
            "Recursos",
            "Execução de Sentença",
            "Arquivamento"
        };
        */

        // incluir Andamentos: Um registro do andamento do processo, com datas e descrições das movimentações.
        // incluir Decisões: Registro das decisões tomadas durante o processo.
        // incluir Jurisdição: A jurisdição onde o processo está ocorrendo (por exemplo, comarca, tribunal).
        // incluir Tipo de processo: Alguma informação sobre a natureza do processo (por exemplo, cível, criminal, trabalhista).
        // incluir configuração para alerta de prazos
    }
}

