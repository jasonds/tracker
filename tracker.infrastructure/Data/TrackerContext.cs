using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using tracker.domain.Models;

namespace tracker.infrastructure.Data
{
    public class TrackerContext : DbContext
    {
        public TrackerContext()
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            this.UserSetup(modelBuilder);
        }

        private void UserSetup(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(p => p.FirstName)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(p => p.LastName)
                .IsRequired();
        }
    }
}
