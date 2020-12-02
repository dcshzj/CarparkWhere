using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarparkWhere.Models.Users
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
    }
}
