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
    public class TestSchemeFacade
    {
        private readonly AppDbContext context;
        public TestSchemeFacade(AppDbContext context)
        {
            this.context = context;
        }

        public void Create(TestSchemeDTO dto, List<int> topicsIds, List<int> studentGroupIds)
        {
            TestScheme entity = Mapping.Mapper.Map<TestScheme>(dto);
            foreach(var topicId in topicsIds)
            {
                entity.Topics.Add(context.Topics.Find(topicId));
            }
            foreach(var studentGroupId in studentGroupIds)
            {
                entity.Groups.Add(context.StudentGroups.Find(studentGroupId));
            }
            context.TestSchemes.Add(entity);
            context.SaveChanges();
        }

        public void Create(TestSchemeDTO dto)
        {
            Create(dto, new List<int>(), new List<int>());
        }

        public void Remove(TestSchemeDTO dto)
        {
            TestScheme entity = Mapping.Mapper.Map<TestScheme>(dto);
            context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
        }

        public void RemoveById(int id)
        {
            var toDelete = context.TestSchemes.Where(x => x.Id == id).FirstOrDefault();
            toDelete.Groups.Clear();
            toDelete.Topics.Clear();
            context.TestSchemes.Remove(toDelete);
            context.SaveChanges();
        }

        public void Update(TestSchemeDTO dto)
        {
            Update(dto, new List<int>(), new List<int>());
        }

        public void Update(TestSchemeDTO dto, List<int> topicsIds, List<int> studentGroupIds)
        {
            TestScheme entity = context.TestSchemes.Find(dto.Id);
            Mapping.Mapper.Map<TestSchemeDTO, TestScheme>(dto, entity);

            foreach (var topicId in topicsIds)
            {
                entity.Topics.Add(context.Topics.Find(topicId));
            }
            foreach (var studentGroupId in studentGroupIds)
            {
                entity.Groups.Add(context.StudentGroups.Find(studentGroupId));
            }
            context.SaveChanges();
        }

        public List<TestSchemeDTO> ListAll()
        {
            using (var context = new AppDbContext())
            {
                List<TestSchemeDTO> dtos = new List<TestSchemeDTO>();
                foreach (var entity in context.TestSchemes.ToList())
                {
                    dtos.Add(Mapping.Mapper.Map<TestSchemeDTO>(entity));
                }
                return dtos;
            }
        }

        public TestSchemeDTO FindById(int id)
        {
            return Mapping.Mapper.Map<TestSchemeDTO>(
                    context.TestSchemes.Find(id));
        }
    }
}
