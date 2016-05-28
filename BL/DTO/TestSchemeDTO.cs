using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTO
{
    public class TestSchemeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TopicDTO> Topics { get; set; }
        public int QuestionsAmount { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{0:dd\/MM \/yyyy}")]
        public DateTime TestTime { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{0:dd\/MM\/yyyy}")]
        public DateTime OpenTime { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{0:dd\/MM\/yyyy}")]
        public DateTime CloseTime { get; set; }
        public List<StudentGroupDTO> Groups { get; set; }

        public TestSchemeDTO()
        {
            Topics = new List<TopicDTO>();
            Groups = new List<StudentGroupDTO>();
        }
    }
}
