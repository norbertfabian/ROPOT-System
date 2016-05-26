using BL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class TopicEditViewModel : TopicDetailModel
    {
        public List<TopicDTO> Topics { get; set; }
        public int SelectedParent { get; set; }
        public string Result { get; set; }

        public TopicEditViewModel()
        {
            Topics = new List<TopicDTO>();
        }
    }
}