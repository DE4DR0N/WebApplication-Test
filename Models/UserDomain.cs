using WebApplication_Test1.Enums;

namespace WebApplication_Test1.Models
{
    public class UserDomain
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
    }
}
