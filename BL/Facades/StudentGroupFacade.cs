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
        private readonly AppDbContext context;
        public StudentGroupFacade(AppDbContext context)
        {
            this.context = context;
        }

        public void Create(StudentGroupDTO dto)
        {
            StudentGroup entity = Mapping.Mapper.Map<StudentGroup>(dto);
            context.StudentGroups.Add(entity);
            context.SaveChanges();            
        }

        public void Remove(StudentGroupDTO dto)
        {
            StudentGroup entity = Mapping.Mapper.Map<StudentGroup>(dto);
            context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
        }

        public void RemoveById(int id)
        {
            var toDelete = context.StudentGroups.Where(x => x.Id == id).FirstOrDefault();
            context.StudentGroups.Remove(toDelete);
            context.SaveChanges();
        }

        public void Update(StudentGroupDTO dto)
        {
            var entity = context.StudentGroups.Find(dto.Id);
            context.Entry(entity).CurrentValues.SetValues(Mapping.Mapper.Map<StudentGroup>(dto));
            foreach (var userDto in dto.Students)
            {
                var userEntity = context.Users.Find(userDto.Id);
                if (!entity.Students.Contains(userEntity))
                {
                    entity.Students.Add(userEntity);
                }
            }
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();            
        }

        public List<StudentGroupDTO> ListAll()
        {
            List<StudentGroupDTO> dtos = new List<StudentGroupDTO>();
            foreach (var entity in context.StudentGroups.ToList())
            {
                dtos.Add(Mapping.Mapper.Map<StudentGroupDTO>(entity));
            }
            return dtos;
            
        }

        public List<StudentGroupDTO> ListAllWithStudents()
        {
            List<StudentGroupDTO> dtos = new List<StudentGroupDTO>();
            foreach (var entity in context.StudentGroups.Include("Students").ToList())
            {
                dtos.Add(Mapping.Mapper.Map<StudentGroupDTO>(entity));
            }
            return dtos;            
        }

        public StudentGroupDTO FindById(int id)
        {
            return Mapping.Mapper.Map<StudentGroupDTO>(
            context.StudentGroups.Find(id));
        }
    }
}
