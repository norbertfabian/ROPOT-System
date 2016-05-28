using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BL.DTO;

namespace Web.Models
{
    public class QuestionEditModel
    {
        public QuestionDTO Question { get; set; }
        public List<TopicDTO> Topics { get; set; }
        public int selectedTopic { get; set; }

        public QuestionEditModel()
        {
            Topics = new List<TopicDTO>();
        }
    }
}