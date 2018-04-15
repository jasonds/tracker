using System;

namespace tracker.web.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public string Status { get; set; }
    }
}