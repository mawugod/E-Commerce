﻿using Microsoft.AspNetCore.Identity;

namespace Secomez.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }
}
