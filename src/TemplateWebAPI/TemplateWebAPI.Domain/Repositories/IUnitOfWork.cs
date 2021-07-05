using System.Threading.Tasks;

namespace $safeprojectname$.Repositories
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();

    }
}
