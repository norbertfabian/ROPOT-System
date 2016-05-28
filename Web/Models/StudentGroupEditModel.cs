using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BL.DTO;

namespace Web.Models
{
    public class StudentGroupEditModel { 

        public StudentGroupDTO StudentGroup { get; set; }
        public string Result { get; set; }

        public StudentGroupEditModel()
        {

        }
    }
}