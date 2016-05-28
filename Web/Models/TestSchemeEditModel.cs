using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BL.DTO;

namespace Web.Models
{
    public class TestSchemeEditModel
    {
        public TestSchemeDTO TestScheme { get; set; }
        public List<int> SelectedTopics { get; set; }
        public List<TopicDTO> Topics { get; set; }
        public List<int> SelectedStudentGroups { get; set; }
        public List<StudentGroupDTO> StudentGroups { get; set; }

        public TestSchemeEditModel()
        {
            SelectedTopics = new List<int>();
            Topics = new List<TopicDTO>();
            SelectedStudentGroups = new List<int>();
            StudentGroups = new List<StudentGroupDTO>();
        }
    }
}