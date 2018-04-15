using System.Threading.Tasks;

namespace tracker.domain.Services
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}
