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

namespace BL.Facades
{
    public class RoleFacade
    {       
        public void Create(RoleDTO dto)
        {
            Role entity = Mapping.Mapper.Map<Role>(dto);

            using (var context = new AppDbContext())
            {
                context.Roles.Add(entity);
                context.SaveChanges();
            }
        }

        public void Remove(RoleDTO dto)
        {
            Role entity = Mapping.Mapper.Map<Role>(dto);

            using (var context = new AppDbContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Update(RoleDTO dto)
        {
            Role entity = Mapping.Mapper.Map<Role>(dto);

            using (var context = new AppDbContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public List<RoleDTO> ListAll()
        {
            using (var context = new AppDbContext())
            {
                List<RoleDTO> dtos = new List<RoleDTO>();
                foreach (var entity in context.Roles.ToList())
                {
                    dtos.Add(Mapping.Mapper.Map<RoleDTO>(entity));
                }
                return dtos;
            }
        }

        public RoleDTO FindById(int id)
        {
            using (var context = new AppDbContext())
            {
                return Mapping.Mapper.Map<RoleDTO>(
                    context.Roles.Find(id));
            }
        }
    }
}
