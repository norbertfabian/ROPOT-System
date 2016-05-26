using DAL;
using DAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BL
{
    public class AppUserStore : UserStore<User, Role, int, UserLogin, UserRole, UserClaim>
    {
        public AppUserStore(AppDbContext context) : base(context)
        {
        }
    }
}