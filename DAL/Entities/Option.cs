using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Option
    {
        public int Id { get; set; }
        [Required]
        public Question Question { get; set; }
        public String Text { get; set; }
        public bool Correct { get; set; }
        public String Description { get; set; }
        public Option()
        {

        }
    }
}
