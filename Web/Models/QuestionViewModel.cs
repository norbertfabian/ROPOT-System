using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BL.DTO;

namespace Web.Models
{
    public class QuestionViewModel
    {
        public List<QuestionDTO> Questions { get; set; }

        public QuestionViewModel()
        {
            Questions = new List<QuestionDTO>();
        }
    }
}