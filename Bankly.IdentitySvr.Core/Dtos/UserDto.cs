using System;
using System.ComponentModel.DataAnnotations;

namespace Bankly.IdentitySvr.Core.Dtos
{
    public class UserReqDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }

    public class UserDto : UserReqDto
    {
        public string Id { get; set; }
    }
}
