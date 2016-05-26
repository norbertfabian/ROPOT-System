using DAL.Entities;
using DAL;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BL
{
    public class AppRoleStore : RoleStore<Role, int, UserRole>
    {
        public AppRoleStore(AppDbContext context) : base(context)
        {
        }
    }
}