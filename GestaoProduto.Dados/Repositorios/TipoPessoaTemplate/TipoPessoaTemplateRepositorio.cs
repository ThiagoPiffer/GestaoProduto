using GestaoProduto.Dados.Contextos;
using GestaoProduto.Dados.Repositorio._RepositorioBase;
using GestaoProduto.Dominio.IRepositorio._TipoPessoaTemplateRepositorio;
using GestaoProduto.Dominio.Entity._TipoPessoaTemplate;
using GestaoProduto.Dominio.Entity._TipoPessoa;
using Microsoft.EntityFrameworkCore;
using GestaoProduto.Dominio.Model._PessoasProcesso;
using GestaoProduto.Dominio.Model._TipoPessoaTemplate;

namespace GestaoProduto.Dados.Repositorios._TipoPessoaTemplate
{
    public class TipoPessoaTemplateRepositorio : RepositorioBase<TipoPessoaTemplate>, ITipoPessoaTemplateRepositorio
    {
        public TipoPessoaTemplateRepositorio(ApplicationDbContext context) : base(context)
        {

        }

        public async Task AdicionarTipoPessoaTemplate(List<TipoPessoaTemplate> lista)
        {
            try
            {
                // Define DataCadastro e Ativo para cada item na lista
                foreach (var item in lista)
                {
                    item.DataCadastro = DateTime.Now; // Define a data atual
                    item.Ativo = true; // Define como verdadeiro
                }

                await Context.AddRangeAsync(lista); // Agora adiciona a lista ao contexto
                await Context.SaveChangesAsync(); // Salva as alterações no banco de dados
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null) ex = ex.InnerException;
                Console.WriteLine(ex.Message);
            }
        }

        public List<TipoPessoaTemplateModel> ListarTiposPessoaTemplate(int idArquivoTemplate)
        {
            var listaTiposPessoa = Context.TipoPessoa.ToList();

            var tiposPessoaTemplates = Context.TipoPessoaTemplate
                .Where(tpt => tpt.IdArquivoProcessoTemplate == idArquivoTemplate)
                .ToList();

            return tiposPessoaTemplates.Select(tpt => new TipoPessoaTemplateModel
            {
                Id = tpt.Id,
                IdTipoPessoa = tpt.IdTipoPessoa,
                IdArquivoProcessoTemplate = tpt.IdArquivoProcessoTemplate,
                CampoChave = tpt.CampoChave,
                Ativo = tpt.Ativo,
                Descricao = listaTiposPessoa.FirstOrDefault(tp => tp.Id == tpt.IdTipoPessoa)?.Descricao ?? ""
            }).ToList();
        }

    }
}
