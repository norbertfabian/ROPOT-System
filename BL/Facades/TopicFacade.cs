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
    public class TopicFacade
    {
        public void Create(TopicDTO dto)
        {
            Topic entity = Mapping.Mapper.Map<Topic>(dto);

            using (var context = new AppDbContext())
            {
                context.Topics.Add(entity);
                context.SaveChanges();
            }
        }

        public void Remove(TopicDTO dto)
        {
            Topic entity = Mapping.Mapper.Map<Topic>(dto);

            using (var context = new AppDbContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Update(RoleDTO dto)
        {
            Topic entity = Mapping.Mapper.Map<Topic>(dto);

            using (var context = new AppDbContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public List<TopicDTO> ListAll()
        {
            using (var context = new AppDbContext())
            {
                List<TopicDTO> dtos = new List<TopicDTO>();
                foreach (var entity in context.Roles.ToList())
                {
                    dtos.Add(Mapping.Mapper.Map<TopicDTO>(entity));
                }
                return dtos;
            }
        }
    }
}
