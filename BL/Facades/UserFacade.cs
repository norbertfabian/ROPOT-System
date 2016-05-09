using BL.DTO;
using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Facades
{
    public class UserFacade
    {
        public void Create(UserDTO dto)
        {
            User entity = Mapping.Mapper.Map<User>(dto);

            using (var context = new AppDbContext())
            {
                context.Users.Add(entity);
                context.SaveChanges();
            }
        }

        public void Remove(UserDTO dto)
        {
            User entity = Mapping.Mapper.Map<User>(dto);

            using (var context = new AppDbContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Update(UserDTO dto)
        {
            User entity = Mapping.Mapper.Map<User>(dto);

            using (var context = new AppDbContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public List<UserDTO> ListAll()
        {
            using (var context = new AppDbContext())
            {
                List<UserDTO> dtos = new List<UserDTO>();
                foreach (var entity in context.Roles.ToList())
                {
                    dtos.Add(Mapping.Mapper.Map<UserDTO>(entity));
                }
                return dtos;
            }
        }

        public UserDTO FindById(int id)
        {
            using (var context = new AppDbContext())
            {
                return Mapping.Mapper.Map<UserDTO>(
                    context.Users.Find(id));
            }
        }
    }
}
