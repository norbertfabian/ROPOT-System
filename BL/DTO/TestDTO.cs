using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTO
{
    public class TestDTO
    {
        public int Id { get; set; }
        public virtual UserDTO User { get; set; }
        public virtual TestSchemeDTO TestScheme { get; set; }
        public virtual Dictionary<QuestionDTO, bool> Questions { get; set; }
        public int Score { get; set; }
        public int MaxPoints { get; set; }

        public TestDTO()
        {
            Questions = new Dictionary<QuestionDTO, bool>();
        }
    }
}
