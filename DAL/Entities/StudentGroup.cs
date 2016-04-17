using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class StudentGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Students { get; set; }
        public StudentGroup()
        {
            Students = new List<User>();
        }
    }
}
