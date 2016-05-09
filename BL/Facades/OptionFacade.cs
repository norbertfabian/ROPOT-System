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
        public void Create(OptionDTO dto)
        {
            Option entity = Mapping.Mapper.Map<Option>(dto);

            using (var context = new AppDbContext())
            {
                context.Options.Add(entity);
                context.SaveChanges();
            }
        }

        public void Remove(OptionDTO dto)
        {
            Option entity = Mapping.Mapper.Map<Option>(dto);

            using (var context = new AppDbContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Update(OptionDTO dto)
        {
            Option entity = Mapping.Mapper.Map<Option>(dto);

            using (var context = new AppDbContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public List<OptionDTO> ListAll()
        {
            using (var context = new AppDbContext())
            {
                List<OptionDTO> dtos = new List<OptionDTO>();
                foreach (var entity in context.Options.ToList()) 
                {
                    dtos.Add(Mapping.Mapper.Map<OptionDTO>(entity));
                }
                return dtos;
            }
        }

        public OptionDTO FindById(int id)
        {
            using (var context = new AppDbContext())
            {
                return Mapping.Mapper.Map<OptionDTO>(
                    context.Options.Find(id));
            }
        }
    }
}
