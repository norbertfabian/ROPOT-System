using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Topic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Topic Parent { get; set; }
        public virtual List<Question> questions { get; set; }
        public Topic()
        {

        }
    }
}
