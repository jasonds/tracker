using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using tracker.domain.Models;

namespace tracker.domain.Repositories
{
    public interface IUserRepository
    {
        Task<ICollection<User>> GetAllAsync();

        Task<User> GetByIdAsync(Guid id);

        User Add(User user);
    }
}
