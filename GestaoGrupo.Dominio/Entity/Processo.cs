using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._Empresa;
using GestaoProduto.Dominio.Entity._GrupoProcesso;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoProduto.Dominio.Entity._Processo
{
    public class Processo : Entidade
    {
        public Processo() { }
        
        public string Numero { get; set; }
        public string? Descricao { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataPrevista { get; set; }
        public DateTime? DataFinal { get; set; }
        public string? MotivoFinal { get; set; }

        [DecimalPrecision(16, 2)]
        public Double? ValorCausa { get; set; }
        public int GrupoProcessoId { get; set; }
        public GrupoProcesso GrupoProcesso { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }



        // incluir pessoas: Uma breve descrição do caso e dos problemas legais envolvidos.
        // incluir advogados: envolvidos Os advogados que estão representando as partes no processo.
        // incluir Fases do processo: 
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

