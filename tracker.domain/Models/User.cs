using System;

namespace tracker.domain.Models
{
    public class User : IIdentifiable<Guid>
    {
        public User(Guid id)
            : this()
        {
            if (id == Guid.Empty) throw new ArgumentException(nameof(id));
            this.Id = id;
        }

        private User()
        {
        }

        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Location { get; set; }

        public string Status { get; set; }

        public bool IsBench { get; set; }

        public DateTime LastUpdatedUtc { get; set; }
    }
}
