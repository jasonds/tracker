using System;
using System.ComponentModel.DataAnnotations;

namespace tracker.web.ViewModels
{
    public class NewUserViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Location { get; set; }

        public string Status { get; set; }

        public bool IsBench { get; set; }
    }
}
