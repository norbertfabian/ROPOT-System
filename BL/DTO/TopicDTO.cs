﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTO
{
    public class TopicDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TopicDTO> Childs { get; set; }
        public TopicDTO Parent { get; set; }
        public List<QuestionDTO> Questions { get; set; }
        public virtual List<TestSchemeDTO> TestSchemes { get; set; }
        public TopicDTO()
        {
            Questions = new List<QuestionDTO>();
            TestSchemes = new List<TestSchemeDTO>();
        }
    }
}
