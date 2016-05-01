using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTO
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool OneCorrectType { get; set; }
        public float Points { get; set; }
        public TopicDTO Topic { get; set; }
        public List<OptionDTO> Options { get; set; }


        public QuestionDTO()
        {
            Options = new List<OptionDTO>();
        }
    }
}
