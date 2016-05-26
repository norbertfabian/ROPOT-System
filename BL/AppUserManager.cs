using DAL.Entities;
using Microsoft.AspNet.Identity;

namespace BL
{
    public class AppUserManager : UserManager<User, int>
    {
        public AppUserManager(IUserStore<User, int> store) : base(store)
        {
        }
    }
}