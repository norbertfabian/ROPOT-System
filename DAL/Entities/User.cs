using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DAL.Entities
{
    public class User : IdentityUser<int, UserLogin, UserRole, UserClaim>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public virtual Role role { get; set; }
        public virtual List<StudentGroup> studentGroups { get; set; }
        public User()
        {

        }
    }
}
