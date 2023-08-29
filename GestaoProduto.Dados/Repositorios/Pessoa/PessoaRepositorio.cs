using GestaoProduto.Dados.Contextos;
using GestaoProduto.Dominio.Entity;
using GestaoProduto.Dominio.Model;
using GestaoProduto.Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace GestaoProduto.Dados.Repositorios
{
    public class PessoaRepositorio : RepositorioBase<Pessoa>, IPessoaRepositorio
    {
        public PessoaRepositorio(ApplicationDbContext context) : base(context)
        { }

        public async Task<List<PessoasProcessoModel>> ListarPessoasProcesso(int idProcesso)
        {
            // Etapa 1: Obter dados do banco de dados
            var pessoasProcesso = await Context.PessoasProcesso.Where(pp => pp.ProcessoId == idProcesso).ToListAsync();

            var pessoasIds = pessoasProcesso.Select(pp => pp.PessoaId).ToList();
            var pessoas = await Context.Pessoas
                .Where(p => pessoasIds.Contains(p.Id))
                .ToListAsync();

            // Etapa 2: Manipular os dados na memória para obter o resultado desejado
            var pessoaProcesssoModel = pessoas.Select(p => new PessoasProcessoModel
            {
                Id = p.Id,
                Nome = p.Nome,
                DataNascimento = p.DataNascimento.HasValue ? p.DataNascimento.Value.ToShortDateString() : "",
                //Idade = p.Idade,
                Email = p.Email,
                CPFCNPJ = p.CPFCNPJ,
                Identidade = p.Identidade,
                DDDTelefone = p.DDDTelefone,
                Telefone = p.Telefone,
                DDDCelular = p.DDDCelular,
                Celular = p.Celular,
                TipoPessoaDescricao = pessoasProcesso
                    .Where(pp => pp.PessoaId == p.Id && pp.TipoPessoaProcesso != null)
                    .Select(pp => pp.TipoPessoaProcesso?.Descricao)
                    .FirstOrDefault(),
                Ativo = p.Ativo
            }).ToList();


            return pessoaProcesssoModel;
        }




        public async Task<List<GrupoProcessoModel>> ListarGrupoProcessoModel()
        {
            var grupos = await Context.Processos
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
