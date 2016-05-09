using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using DAL.Entities;

namespace BL
{
    public class BussinessRoleManager : RoleManager<Role, int>
    {
        public BussinessRoleManager(IRoleStore<Role, int> store) : base(store)
        {
        }
    }
}
