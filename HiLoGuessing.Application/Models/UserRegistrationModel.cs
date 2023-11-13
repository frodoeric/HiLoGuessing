using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiLoGuessing.Application.Models
{
    public class UserRegistrationModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public object FirstName { get; set; }
        public object LastName { get; set; }
    }

}
