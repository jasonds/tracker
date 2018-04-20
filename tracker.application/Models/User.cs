using System;

namespace tracker.application.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Location { get; set; }

        public string Status { get; set; }

        public bool IsBench { get; set; }
    }
}
