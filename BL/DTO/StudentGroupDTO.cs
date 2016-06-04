using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTO
{
    public class StudentGroupDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public List<UserDTO> Students { get; set; }
        public virtual List<TestSchemeDTO> TestSchemes { get; set; }

        public StudentGroupDTO()
        {
            Students = new List<UserDTO>();
            TestSchemes = new List<TestSchemeDTO>();
        }
    }
}
