using Microsoft.AspNetCore.Identity;

namespace HiloGuessing.Domain.Entities
{
    public class User : IdentityUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string SecurityStamp { get; set; }
        public object FirstName { get; set; }
        public object LastName { get; set; }
    }

}
