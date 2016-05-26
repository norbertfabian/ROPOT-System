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
    public class QuestionFacade
    {
        public void Create(QuestionDTO dto)
        {
            Question entity = Mapping.Mapper.Map<Question>(dto);

            using (var context = new AppDbContext())
            {
                context.Questions.Add(entity);
                context.SaveChanges();
            }
        }

        public void Remove(QuestionDTO dto)
        {
            Question entity = Mapping.Mapper.Map<Question>(dto);

            using (var context = new AppDbContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }            
        }

        public void Update(QuestionDTO dto)
        {
            Question entity = Mapping.Mapper.Map<Question>(dto);
            Mapping.Mapper.Map<QuestionDTO, Question>(dto, entity);

            using (var context = new AppDbContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public List<QuestionDTO> ListAll()
        {
            using (var context = new AppDbContext())
            {
                List<QuestionDTO> dtos = new List<QuestionDTO>();
                foreach (var entity in context.Questions.ToList())
                {
                    dtos.Add(Mapping.Mapper.Map<QuestionDTO>(entity));
                }
                return dtos;
            }
        }

        public QuestionDTO FindById(int id)
        {
            using (var context = new AppDbContext())
            {
                return Mapping.Mapper.Map<QuestionDTO>(
                    context.Questions.Find(id));
            }
        }
    }
}