using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool OneCorrectType { get; set; }
        public float Points { get; set; }
        [Required]
        public Topic Topic { get; set; }
        [Required]
        public List<Option> Options { get; set; }
        public Question()
        {
            Options = new List<Option>();
        }


    }
}
