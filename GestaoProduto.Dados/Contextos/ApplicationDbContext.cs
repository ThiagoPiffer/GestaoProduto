using Microsoft.EntityFrameworkCore;
using GestaoProduto.Dominio.Entity._Pessoa;
using GestaoProduto.Dominio.Entity._Processo;
using GestaoProduto.Dominio.Entity._GrupoProcesso;
using GestaoProduto.Dominio.Entity._PessoaProcesso;
using GestaoProduto.Dominio.Entity._TipoPessoa;
using GestaoProduto.Dominio.Entity._ArquivoProcesso;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using GestaoProduto.Dominio.Entity._Usuario;
using GestaoProduto.Dominio.Entity._Empresa;
using GestaoProduto.Dominio.Entity._ArquivoProcessoTemplate;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using GestaoProduto.Dominio.Entity._TipoPessoaTemplate;

namespace GestaoProduto.Dados.Contextos
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Processo> Processo { get; set; }
        public DbSet<GrupoProcesso> GrupoProcesso { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<PessoaProcesso> PessoaProcesso { get; set; }
        public DbSet<TipoPessoa> TipoPessoa { get; set; }
        public DbSet<ArquivoProcesso> ArquivoProcesso { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<ArquivoProcessoTemplate> ArquivoProcessotemplate { get; set; }
        public DbSet<TipoPessoaTemplate> TipoPessoaTemplate { get; set; }

        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
        {
            public ApplicationDbContext CreateDbContext(string[] args)
            {
                //var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();                
                //optionsBuilder.UseSqlServer("Data Source=DESKTOP-2V83K63;Database=GestaoProdutoDB;User Id=sa;Password=123456;TrustServerCertificate=true;Encrypt=False;", b => b.MigrationsAssembly("GestaoProduto.Dados"));
                //return new ApplicationDbContext(optionsBuilder.Options);

                // Especifique o caminho para o projeto que contém o appsettings.json                
                var basePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "GestaoProdutoWeb");//sobe uma pasta e abre a pasta mencionada, abaixo ele busca o arquivo json na mao 
                //Console.WriteLine("Base path: " + basePath);


                // Construir o IConfigurationRoot para carregar o appsettings.json
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(basePath)
                    .AddJsonFile("appsettings.json")
                    .Build();

                // Obter a string de conexão do arquivo de configuração
                var connectionString = configuration.GetConnectionString("DataBase");

                // Usar a string de conexão para configurar o DbContext
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                optionsBuilder.UseSqlServer(connectionString, b => b.MigrationsAssembly("GestaoProduto.Dados"));

                return new ApplicationDbContext(optionsBuilder.Options);
            }
        }



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
