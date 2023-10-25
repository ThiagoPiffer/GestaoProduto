using GestaoProduto.Dados.Contextos;
using GestaoProduto.Dominio.Entity._Pessoa;
using GestaoProduto.Dominio.Model._GrupoProcesso;
using GestaoProduto.Dominio.Model._PessoaProcesso;
using GestaoProduto.Dominio.Model._Processo;
using GestaoProduto.Dominio.IRepositorio._Pessoa;
using Microsoft.EntityFrameworkCore;
using GestaoProduto.Dados.Repositorio._RepositorioBase;
using System.Runtime.InteropServices;
using GestaoProduto.Dominio._Base;
using static System.Runtime.InteropServices.JavaScript.JSType;
using GestaoProduto.Dominio.Entity._TipoPessoa;
using GestaoProduto.Dominio.Entity._Empresa;
using GestaoProduto.Dominio.Entity._PessoaProcesso;

namespace GestaoProduto.Dados.Repositorio._Pessoa
{
    public class PessoaRepositorio : RepositorioBase<Pessoa>, IPessoaRepositorio
    {
        public PessoaRepositorio(ApplicationDbContext context) : base(context)
        { }

        public async Task<List<PessoaProcessoModel>> ListarPessoasProcesso(int idProcesso)
        {
            var empresaId = 2;

            //Pessoas no Processo
            var pessoasProcesso = await Context.PessoaProcesso.Where(pp => pp.ProcessoId == idProcesso).ToListAsync();

            var pessoasIds = pessoasProcesso.Select(pp => pp.PessoaId).ToList();

            //Pessoas
            var pessoas = await Context.Pessoa
                .Where(p => pessoasIds.Contains(p.Id))
                .ToListAsync();

            //Tipos Pessoa
            var tiposPessoa = await Context.TipoPessoa.Where(tp => tp.EmpresaId == empresaId).ToListAsync();

            //PessoasProcessoModel
            var pessoaProcesssoModel = pessoas.Select(p =>
            {
                var pessoaProcesso = pessoasProcesso.FirstOrDefault(pp => pp.Id == p.Id);
                var tipoPessoa = pessoaProcesso != null ? tiposPessoa.FirstOrDefault(t => t.Id == pessoaProcesso.TipoPessoaId) : null;

                return new PessoaProcessoModel
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    DataNascimento = p.DataNascimento.HasValue ? p.DataNascimento.Value.ToShortDateString() : "",
                    //Idade = p.Idade, // Comentado conforme estava no seu código original
                    Email = p.Email,
                    CPFCNPJ = p.CPFCNPJ,
                    Identidade = p.Identidade,
                    DDDTelefone = p.DDDTelefone,
                    Telefone = p.Telefone,
                    DDDCelular = p.DDDCelular,
                    Celular = p.Celular,
                    TipoPessoaDescricao = tipoPessoa?.Descricao ?? "", // Se tipoPessoa for null, use um valor padrão
                    Ativo = p.Ativo
                };
            }).ToList();

            return pessoaProcesssoModel;
        }

        public async Task<List<PessoaProcessoModel>> ListarPessoasArquivoTemplate(int idArquivoTemplate, int idProcesso, List<int> idsTiposPessoa)
        {
            var empresaId = 2;

            //Tipos Pessoa
            var tiposPessoa = await Context.TipoPessoa.Where(tp => tp.Ativo &&
                                                                    tp.EmpresaId == empresaId && 
                                                                   idsTiposPessoa.Contains( tp.Id)
            ).ToListAsync();

            var trazerTodos = tiposPessoa.Count == 0; //se for igual a 0 traz todas as pessoas

            //Tipos Pessoa Template
            var idsTipoPessoatemplate = await Context.TipoPessoaTemplate.Where(pp => pp.Ativo &&
                idsTiposPessoa.Contains(pp.TipoPessoaId)
                ).Select(pp => pp.TipoPessoaId).ToListAsync();

            //Pessoas Processo
            var pessoasProcesso = await Context.PessoaProcesso.Where(pp => pp.Ativo &&
                pp.ProcessoId == idProcesso &&
                (trazerTodos || (pp.TipoPessoaId.HasValue && idsTipoPessoatemplate.Contains(pp.TipoPessoaId.Value)))
                ).ToListAsync();

            //Pessoas
            var pessoas = await Context.Pessoa.Where(p => p.Ativo &&            
            pessoasProcesso.Select(pp => pp.Id).Contains(p.Id)).ToListAsync();

            //PessoasProcessoModel
            var pessoasProcessoModel = pessoas.Select(p =>
            {
                var pessoaProcesso = pessoasProcesso.FirstOrDefault(pp => pp.Id == p.Id);
                var tipoPessoa = pessoaProcesso != null ? tiposPessoa.FirstOrDefault(t => t.Id == pessoaProcesso.TipoPessoaId) : null;

                return new PessoaProcessoModel
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    DataNascimento = p.DataNascimento.HasValue ? p.DataNascimento.Value.ToShortDateString() : "",
                    //Idade = p.Idade, // Comentado conforme estava no seu código original
                    Email = p.Email,
                    CPFCNPJ = p.CPFCNPJ,
                    Identidade = p.Identidade,
                    DDDTelefone = p.DDDTelefone,
                    Telefone = p.Telefone,
                    DDDCelular = p.DDDCelular,
                    Celular = p.Celular,
                    idTipoPessoa = tipoPessoa?.Id?? 0,
                    TipoPessoaDescricao = tipoPessoa?.Descricao ?? "", // Se tipoPessoa for null, use um valor padrão
                    Ativo = p.Ativo
                };
            }).ToList();



            return pessoasProcessoModel;
        }


        public async Task<List<GrupoProcessoModel>> ListarGrupoProcessoModel()
        {
            var grupos = await Context.Processo
                .Include(p => p.GrupoProcesso) // Inclui os processos associados ao grupo
                .ToListAsync();

            // Mapeia a lista de grupos para a lista de GrupoProcessoModel
            var listaGrupos = grupos.GroupBy(p => p.GrupoProcesso) // Agrupa os processos por Grupo
                            .Select(g => new GrupoProcessoModel
                            {
                                Id = g.Key.Id,
                                Nome = g.Key.Nome ?? string.Empty,
                                Posicao = g.Key.Posicao,
                                Ativo = g.Key.Ativo,
                                Processos = g.Select(p => new ProcessoModel
                                {
                                    Id = p.Id,
                                    Numero = p.Numero ?? string.Empty,
                                    Descricao = p.Descricao ?? string.Empty,
                                    //DataCadastro = p.DataCadastro.HasValue ? p.DataCadastro.Value.ToShortDateString() : null, // Se for nulo ou vazio retorna null
                                    DataInicio = p.DataInicio.HasValue ? p.DataInicio.Value.ToShortDateString() : null, // Se for nulo ou vazio retorna null
                                    Prazo = p.DataInicio.HasValue && p.DataPrevista.HasValue ? (int?)p.DataPrevista.Value.Subtract(p.DataInicio.Value).TotalDays : null,
                                    //Prazo = 0,
                                    DataPrevista = p.DataPrevista.HasValue ? p.DataPrevista.Value.ToShortDateString() : null, // Se for nulo ou vazio retorna null
                                    DataFinal = p.DataFinal.HasValue ? p.DataFinal.Value.ToShortDateString() : null, // Se for nulo ou vazio retorna null
                                    ValorCausa = p.ValorCausa ?? 0, // Se for nulo retorna 0
                                    Ativo = p.Ativo
                                }).ToList()
                            })
                            .ToList();


            return listaGrupos;
        }
    }
}
