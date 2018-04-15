using tracker.domain.Models;
using tracker.domain.Repositories;
using tracker.infrastructure.Data;

namespace tracker.infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(TrackerContext context)
            : base(context)
        {
        }
    }
}
