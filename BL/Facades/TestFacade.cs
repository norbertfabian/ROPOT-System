using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL;
using BL.DTO;

namespace BL.Facades
{
    public class TestFacade
    {
        AppDbContext context = new AppDbContext();

        public TestFacade(AppDbContext context)
        {
            this.context = context;
        }

        public void Create(TestDTO dto)
        {
            Test entity = Mapping.Mapper.Map<Test>(dto);
            entity.TestScheme = context.TestSchemes.Find(dto.TestScheme.Id);
            entity.User = context.Users.Find(dto.User.Id);
            foreach (var question in dto.Questions.Keys)
            {
                entity.Questions.Add(context.Questions.Find(question.Id), dto.Questions[question]);
            }
            context.Tests.Add(entity);
            context.SaveChanges();
        }

        public void Remove(TestDTO dto)
        {
            Test entity = Mapping.Mapper.Map<Test>(dto);
            context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
        }

        public void Update(TestDTO dto)
        {
            var entity = context.Tests.Find(dto.Id);
            context.Entry(entity).CurrentValues.SetValues(dto);
            entity.TestScheme = context.TestSchemes.Find(dto.TestScheme.Id);
            entity.User = context.Users.Find(dto.User.Id);
            foreach(var question in dto.Questions.Keys)
            {
                entity.Questions.Add(context.Questions.Find(question.Id), dto.Questions[question]);
            }
            context.SaveChanges();
        }

        public List<TestDTO> ListAllForUser(int userId)
        {
            List<TestDTO> dtos = new List<TestDTO>();
            foreach (var entity in context.Tests.Where(t => t.User.Id == userId).ToList())
            {
                dtos.Add(Mapping.Mapper.Map<TestDTO>(entity));
            }
            return dtos;
        }

        public TestDTO FindById(int id)
        {
            return Mapping.Mapper.Map<TestDTO>(
                 context.Tests.Find(id));
        }
    }
}
