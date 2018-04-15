using System.Collections.Generic;
using System.Threading.Tasks;
using AppModel = tracker.application.Models;
using DomainModel = tracker.domain.Models;

namespace tracker.application.Contracts
{
    public interface IUserService
    {
        Task<ICollection<DomainModel.User>> GetAllAsync();

        Task AddAsync(AppModel.User user);

        Task UpdateAsync(ICollection<AppModel.User> user);
    }
}
