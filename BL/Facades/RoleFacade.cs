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
        AppDbContext context = new AppDbContext();

        public RoleFacade(AppDbContext context)
        {
            this.context = context;
        }

        public void Create(RoleDTO dto)
        {
            Role entity = Mapping.Mapper.Map<Role>(dto);
            context.Roles.Add(entity);
            context.SaveChanges();
        }

        public void Remove(RoleDTO dto)
        {
            Role entity = Mapping.Mapper.Map<Role>(dto);
            context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
        }

        public void Update(RoleDTO dto)
        {
            Role entity = Mapping.Mapper.Map<Role>(dto);
            Mapping.Mapper.Map<RoleDTO, Role>(dto, entity);
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public List<RoleDTO> ListAll()
        {
            List<RoleDTO> dtos = new List<RoleDTO>();
            foreach (var entity in context.Roles.ToList())
            {
                dtos.Add(Mapping.Mapper.Map<RoleDTO>(entity));
            }
            return dtos;
        }

        public RoleDTO FindById(int id)
        {
            return Mapping.Mapper.Map<RoleDTO>(
                 context.Roles.Find(id));
        }
    }
}
