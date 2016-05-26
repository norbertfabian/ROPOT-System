using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTO
{
    public class UserDTO : IdentityUser<int, UserLoginDTO, UserRoleDTO, UserClaimDTO>
    {
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public RoleDTO Role { get; set; }
        public List<StudentGroupDTO> StudentGroups { get; set; }

        public UserDTO()
        {

        }
    }
}
