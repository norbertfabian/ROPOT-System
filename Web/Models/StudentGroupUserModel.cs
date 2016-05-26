using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BL.DTO;

namespace Web.Models
{
    public class StudentGroupUserModel
    {
        public int Student { get; set; }
        public List<StudentGroupDTO> StudentGroups { get; set; }
        public int Group { get; set; }
        public string Code { get; set; }
        public string Result { get; set; }

        public StudentGroupUserModel()
        {
            StudentGroups = new List<StudentGroupDTO>();
        }
    }
}