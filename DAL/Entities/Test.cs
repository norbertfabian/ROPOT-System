using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Test
    {
        public int Id { get; set; }
        public virtual User User { get; set; }
        public virtual TestScheme TestScheme { get; set; }
        public virtual Dictionary<Question, bool> Questions { get; set; }
        public int Score { get; set; }
        public int MaxPoints { get; set; }

        public Test()
        {
            Questions = new Dictionary<Question, bool>();
        }
    }
}
