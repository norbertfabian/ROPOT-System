﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class TestScheme
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Topic> Topics { get; set; }
        public int QuestionsAmount { get; set; }
        public DateTime OpenTime { get; set; }
        public DateTime CloseTime { get; set; }
        public virtual List<StudentGroup> Groups { get; set; }
        public TestScheme()
        {
            Topics = new List<Topic>();
            Groups = new List<StudentGroup>();
        }
    }
}
