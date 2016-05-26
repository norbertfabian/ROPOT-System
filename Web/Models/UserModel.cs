using BL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class UserModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public List<RoleDTO> Roles { get; set; }
    }
}