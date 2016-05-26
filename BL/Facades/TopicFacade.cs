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
        private readonly AppDbContext context;

        public TopicFacade(AppDbContext context)
        {
            this.context = context;
        }

        public void Create(TopicDTO dto)
        {
            Create(dto, -1);
        }

        public void Create(TopicDTO dto, int parentId)
        {
            Topic entity = Mapping.Mapper.Map<Topic>(dto);
            context.Topics.Add(entity);

            if (parentId >= 0)
            {
                Topic parent = context.Topics.Find(parentId);
                parent.Childs.Add(entity);
                entity.Parent = parent;

            }
            context.SaveChanges();

        }

        public void Remove(TopicDTO dto)
        {
            Topic entity = Mapping.Mapper.Map<Topic>(dto);
            context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();            
        }

        public void Update(TopicDTO dto)
        {
            Update(dto, -1);            
        }

        public void Update(TopicDTO dto, int parentId)
        {
            Topic entity = context.Topics.Find(dto.Id);
            Mapping.Mapper.Map<TopicDTO, Topic>(dto, entity);
            if (parentId >= 0)
            {
                Topic parent = context.Topics.Find(parentId);
                parent.Childs.Add(entity);
                entity.Parent = parent;
                context.Entry(parent).State = System.Data.Entity.EntityState.Modified;
            }
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public void RemoveById(int id)
        {
            var toDelete = context.Topics.Where(x => x.Id == id).FirstOrDefault();
            context.Topics.Remove(toDelete);
            context.SaveChanges();            
        }

        public List<TopicDTO> ListAll()
        {
            List<TopicDTO> dtos = new List<TopicDTO>();
            foreach (var entity in context.Topics.ToList())
            {
                dtos.Add(Mapping.Mapper.Map<TopicDTO>(entity));
            }
            return dtos;            
        }

        public TopicDTO FindById(int id)
        {
            return Mapping.Mapper.Map<TopicDTO>(
            context.Topics.Find(id));            
        }
    }
}
