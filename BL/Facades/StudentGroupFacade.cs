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
    public class StudentGroupFacade
    {
        public void Create(StudentGroupDTO dto)
        {
            StudentGroup entity = Mapping.Mapper.Map<StudentGroup>(dto);

            using (var context = new AppDbContext())
            {
                context.StudentGroups.Add(entity);
                context.SaveChanges();
            }
        }

        public void Remove(StudentGroupDTO dto)
        {
            StudentGroup entity = Mapping.Mapper.Map<StudentGroup>(dto);

            using (var context = new AppDbContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Update(StudentGroupDTO dto)
        {
            StudentGroup entity = Mapping.Mapper.Map<StudentGroup>(dto);

            using (var context = new AppDbContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public List<StudentGroupDTO> ListAll()
        {
            using (var context = new AppDbContext())
            {
                List<StudentGroupDTO> dtos = new List<StudentGroupDTO>();
                foreach (var entity in context.StudentGroups.ToList())
                {
                    dtos.Add(Mapping.Mapper.Map<StudentGroupDTO>(entity));
                }
                return dtos;
            }
        }

        public List<StudentGroupDTO> ListAllWithStudents()
        {
            using (var context = new AppDbContext())
            {
                List<StudentGroupDTO> dtos = new List<StudentGroupDTO>();
                foreach (var entity in context.StudentGroups.Include("Students").ToList())
                {
                    dtos.Add(Mapping.Mapper.Map<StudentGroupDTO>(entity));
                }
                return dtos;
            }
        }

        public StudentGroupDTO FindById(int id)
        {
            using (var context = new AppDbContext())
            {
                return Mapping.Mapper.Map<StudentGroupDTO>(
                    context.StudentGroups.Find(id));
            }
        }
    }
}
