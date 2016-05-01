using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using BL.DTO;

namespace BL
{
    public static class Mapping
    {
        public static IMapper Mapper { get; }
        static Mapping()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Question, QuestionDTO>().ReverseMap();
                c.CreateMap<Option, OptionDTO>().ReverseMap();
                c.CreateMap<Role, RoleDTO>().ReverseMap();
                c.CreateMap<StudentGroup, StudentGroupDTO>().ReverseMap();
                c.CreateMap<TestScheme, TestSchemeDTO>().ReverseMap();
                c.CreateMap<Topic, TopicDTO>().ReverseMap();
                c.CreateMap<User, UserDTO>().ReverseMap();
            });

            Mapper = config.CreateMapper();
        }
    }
}
