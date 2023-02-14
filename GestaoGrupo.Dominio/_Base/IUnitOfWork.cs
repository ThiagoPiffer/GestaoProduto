using System.Threading.Tasks;

namespace GestaoProduto.Dominio._Base
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
