using BL.DTO;
using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Services;

namespace BL.Facades
{
    public class QuestionFacade
    {
        private readonly AppDbContext context;

        public QuestionFacade(AppDbContext context)
        {
            this.context = context;
        }

        public void Create(QuestionDTO dto, int topicId)
        {
            Question entity = Mapping.Mapper.Map<Question>(dto);
            context.Questions.Add(entity);
            if (topicId >= 0)
            {
                Topic topic = context.Topics.Find(topicId);
                entity.Topic = topic;

            }
            context.SaveChanges();
        }

        public void Create(QuestionDTO dto)
        {
            Create(dto, -1);
        }

        public void Remove(QuestionDTO dto)
        {
            Question entity = Mapping.Mapper.Map<Question>(dto);
            context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();           
        }

        public void RemoveById(int id)
        {
            var toDelete = context.Questions.Where(x => x.Id == id).FirstOrDefault();
            context.Questions.Remove(toDelete);
            context.SaveChanges();
        }

        public void Update(QuestionDTO dto)
        {
            Update(dto, -1);
        }

        public void Update(QuestionDTO dto, int topicId)
        {
            Question entity = context.Questions.Find(dto.Id);
            context.Entry(entity).CurrentValues.SetValues(dto);
            if (topicId >= 0)
            {
                Topic topic = context.Topics.Find(topicId);
                entity.Topic = topic;
            }
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public List<QuestionDTO> ListAll()
        {
            List<QuestionDTO> dtos = new List<QuestionDTO>();
            foreach (var entity in context.Questions.ToList())
            {
                dtos.Add(Mapping.Mapper.Map<QuestionDTO>(entity));
            }
            return dtos;
        }

        public QuestionDTO FindById(int id)
        {
            return Mapping.Mapper.Map<QuestionDTO>(
                   context.Questions.Find(id));
        }
    }
}