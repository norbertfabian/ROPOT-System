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
        public virtual Question Question { get; set; }
        public string Text { get; set; }
        public bool Correct { get; set; }
        public string Description { get; set; }
        public Option()
        {

        }
    }
}
