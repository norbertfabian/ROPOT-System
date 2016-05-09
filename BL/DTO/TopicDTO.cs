using System;
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
        public TopicDTO Parent { get; set; }
        public List<QuestionDTO> Questions { get; set; }
        public TopicDTO()
        {

        }
    }
}
