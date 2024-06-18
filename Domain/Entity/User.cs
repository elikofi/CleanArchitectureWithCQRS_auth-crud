﻿


using Microsoft.AspNetCore.Identity;

namespace Domain.Entity
{
    public class User : IdentityUser
    {
        //public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        //public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;    
    }
}
