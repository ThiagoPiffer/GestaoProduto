using GestaoProduto.Compartilhado.Interfaces.Repositorio._IdentidadeCurrent;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._Usuario;
using GestaoProduto.Dados.Contextos;
using GestaoProduto.Dados.Repositorio._RepositorioBase;
using GestaoProduto.Dominio.Entity._Empresa;
using GestaoProduto.Dominio.Entity._Usuario;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProduto.Dados.Repositorios
{
    public class IdentidadeCurrentRepositorio : RepositorioBase<Usuario>, IIdentidadeCurrentRepositorio
    {
        public IdentidadeCurrentRepositorio(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<Usuario> ObterUsuarioCurrentAsync(Guid idAspNetUser)
        {
            var usuario = await Context.Usuario
                                        .Include(u => u.Empresa)
                                        .FirstOrDefaultAsync(u => u.AspNetUserId == idAspNetUser.ToString());
            return usuario;
        }

        public async Task<Empresa> ObterEmpresaCurrentAsync(Guid idAspNetUser)
        {            
            var usuario = await this.ObterUsuarioCurrentAsync(idAspNetUser);
            return usuario?.Empresa!;
        }
    }
}
