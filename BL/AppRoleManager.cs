using DAL.Entities;
using Microsoft.AspNet.Identity;

namespace BL
{
    public class AppRoleManager : RoleManager<Role, int>
    {
        public AppRoleManager(IRoleStore<Role, int> store) : base(store)
        {
        }
    }
}