using System;
using Microsoft.AspNetCore.Identity;

namespace Bankly.IdentitySvr.Respository.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
