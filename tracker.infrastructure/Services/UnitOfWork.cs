using System;
using System.Threading.Tasks;
using tracker.domain.Services;
using tracker.infrastructure.Data;

namespace tracker.infrastructure.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TrackerContext _context;

        public UnitOfWork(TrackerContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            _context = context;
        }
        public async Task<int> SaveChangesAsync()
        {
            return await this._context.SaveChangesAsync();
        }
    }
}
