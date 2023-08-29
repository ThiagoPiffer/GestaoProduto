using Microsoft.EntityFrameworkCore;
using GestaoProduto.Dominio.Entity;

namespace GestaoProduto.Dados.Contextos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<ObjetoCustomizado> ObjetosCustomizados { get; set; }
        public DbSet<Processo> Processos { get; set; }
        public DbSet<GrupoProcesso> GrupoProcessos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<PessoasProcesso> PessoasProcesso { get; set; }
        public DbSet<TipoPessoaProcesso> TipoPessoaProcesso { get; set; }
        public DbSet<ArquivoProcesso> ArquivoProcesso { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties()))
            {
                if (property.ClrType == typeof(DateTime))
                {
                    property.SetColumnType("datetime");
                }

                if (property.ClrType == typeof(DateTime?))
                {
                    property.SetColumnType("datetime");
                }
            }


            modelBuilder.Entity<Processo>()
            .HasOne(p => p.GrupoProcesso)
            .WithMany()
            .HasForeignKey(p => p.GrupoProcessoId);

            //modelBuilder.Entity<ArquivoProcesso>()
            //.Property(ap => ap.ConteudoArquivo)
            //.HasColumnType("varbinary(max)");


            base.OnModelCreating(modelBuilder);
        }

        public async Task Commit()
        {
            await SaveChangesAsync();
        }
    }
}
