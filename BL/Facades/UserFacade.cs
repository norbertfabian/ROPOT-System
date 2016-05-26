using BL.DTO;
using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;

namespace BL.Facades
{
    public class UserFacade
    {
        public Func<AppUserManager> UserManagerFactory { get; set; }
        private AppDbContext context;

        public UserFacade(AppDbContext context)
        {
            this.context = context;
        }

        public void Register(UserDTO user, string role)
        {
            var userManager = UserManagerFactory.Invoke();

            var appUser = Mapping.Mapper.Map<User>(user);

            userManager.Create(appUser, user.Password);

            userManager.AddToRole(appUser.Id, role);
        }

        public ClaimsIdentity Login(string email, string password)
        {
            using (var userManager = UserManagerFactory.Invoke())
            {
                var wantedUser = userManager.FindByEmail(email);

                if (wantedUser == null)
                {
                    return null;
                }

                var user = userManager.Find(wantedUser.UserName, password);

                if (user == null)
                {
                        return null;
                }

                return userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

            }
        }

        public void Create(UserDTO dto)
        {
            User entity = Mapping.Mapper.Map<User>(dto);            
            context.Users.Add(entity);
            context.SaveChanges();            
        }

        public void Remove(UserDTO dto)
        {
            User entity = Mapping.Mapper.Map<User>(dto);
            context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();            
        }

        public void Update(UserDTO dto)
        {
            //var entity = context.Users.Find(dto.Id);
            var entity = Mapping.Mapper.Map<User>(dto);
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            context.Users.Attach(entity);
            context.Entry(entity).CurrentValues.SetValues(Mapping.Mapper.Map<User>(dto));
            context.SaveChanges();            
        }

        public List<UserDTO> ListAll()
        {
            List<UserDTO> dtos = new List<UserDTO>();
            foreach (var entity in context.Roles.ToList())
            {
                dtos.Add(Mapping.Mapper.Map<UserDTO>(entity));
            }
            return dtos;            
        }

        public UserDTO FindById(int id)
        {
            return Mapping.Mapper.Map<UserDTO>(
                    context.Users.Find(id));
        }
    }
}
