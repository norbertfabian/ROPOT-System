using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BL.DTO;

namespace Web.Models
{
    public class TopicViewModel
    {
        public List<TopicDTO> Topics { get; set; }
        public string Result { get; set; }

        public TopicViewModel()
        {
            Topics = new List<TopicDTO>();
        }
    }
}