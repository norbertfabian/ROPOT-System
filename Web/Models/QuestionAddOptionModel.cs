using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BL.DTO;

namespace Web.Models
{
	public class QuestionAddOptionModel
	{
        public int QuestionId { get; set; }
        public OptionDTO Option { get; set; }

        public QuestionAddOptionModel()
        {

        }
	}
}