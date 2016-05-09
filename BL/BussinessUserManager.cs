using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using DAL.Entities;

namespace BL
{
    public class BussinessUserManager : UserManager<User, int>
    {
        public BussinessUserManager(IUserStore<User, int> store) : base(store)
        {
        }
    }
}
