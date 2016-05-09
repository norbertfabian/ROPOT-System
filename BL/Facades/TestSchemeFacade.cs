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
        public void Create(TestSchemeDTO dto)
        {
            TestScheme entity = Mapping.Mapper.Map<TestScheme>(dto);

            using (var context = new AppDbContext())
            {
                context.TestSchemes.Add(entity);
                context.SaveChanges();
            }
        }

        public void Remove(TestSchemeDTO dto)
        {
            TestScheme entity = Mapping.Mapper.Map<TestScheme>(dto);

            using (var context = new AppDbContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Update(TestSchemeDTO dto)
        {
            TestScheme entity = Mapping.Mapper.Map<TestScheme>(dto);

            using (var context = new AppDbContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public List<TestSchemeDTO> ListAll()
        {
            using (var context = new AppDbContext())
            {
                List<TestSchemeDTO> dtos = new List<TestSchemeDTO>();
                foreach (var entity in context.Roles.ToList())
                {
                    dtos.Add(Mapping.Mapper.Map<TestSchemeDTO>(entity));
                }
                return dtos;
            }
        }

        public TestSchemeDTO FindById(int id)
        {
            using (var context = new AppDbContext())
            {
                return Mapping.Mapper.Map<TestSchemeDTO>(
                    context.TestSchemes.Find(id));
            }
        }
    }
}
