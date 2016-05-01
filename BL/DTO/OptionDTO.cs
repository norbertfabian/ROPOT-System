using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTO
{
    public class OptionDTO
    {
        public int Id { get; set; }
        public QuestionDTO Question { get; set; }
        public string Text { get; set; }
        public bool Correct { get; set; }
        public string Description { get; set; }

        public OptionDTO()
        {

        }
    }
}
