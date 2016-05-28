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
    public class OptionFacade
    {
        private readonly AppDbContext context;

        public OptionFacade(AppDbContext context)
        {
            this.context = context;
        }

        public void Create(OptionDTO dto)
        {
            Option entity = Mapping.Mapper.Map<Option>(dto);
            entity.Question = context.Questions.Find(dto.Question.Id);
            context.Options.Add(entity);
            context.SaveChanges();
        }

        public void Remove(OptionDTO dto)
        {
            Option entity = Mapping.Mapper.Map<Option>(dto);
            context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
        }

        public void RemoveById(int id)
        {
            var toDelete = context.Options.Where(x => x.Id == id).FirstOrDefault();
            context.Options.Remove(toDelete);
            context.SaveChanges();
        }

        public void Update(OptionDTO dto)
        {
            Option entity = Mapping.Mapper.Map<Option>(dto);
            Mapping.Mapper.Map<OptionDTO, Option>(dto, entity);
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public List<OptionDTO> ListAll()
        {
            List<OptionDTO> dtos = new List<OptionDTO>();
            foreach (var entity in context.Options.ToList()) 
            {
                dtos.Add(Mapping.Mapper.Map<OptionDTO>(entity));
            }
            return dtos;
        }

        public OptionDTO FindById(int id)
        {
            return Mapping.Mapper.Map<OptionDTO>(
                context.Options.Find(id));
        }
    }
}
