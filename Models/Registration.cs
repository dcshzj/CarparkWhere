using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CarparkWhere.Models.Users
{
    public class Registration
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Password { get; set; }

        public string ContactNumber { get; set; }
    }
}
