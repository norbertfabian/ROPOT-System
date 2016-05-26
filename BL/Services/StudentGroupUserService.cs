using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Facades;
using BL.DTO;

namespace BL.Services
{
    public class StudentGroupUserService
    {
        private readonly UserFacade userFacade;
        private readonly StudentGroupFacade studentGroupFacade;

        public StudentGroupUserService(UserFacade userFacade, StudentGroupFacade studentGroupFacade)
        {
            this.userFacade = userFacade;
            this.studentGroupFacade = studentGroupFacade;
        }

        public bool AddStudentToStudentGroupByCode(int studentId, int groupId, string code)
        {
            StudentGroupDTO studentGroup =  studentGroupFacade.FindById(groupId);
            if (studentGroup.Code.Equals(code))
            {
                UserDTO student = userFacade.FindById(studentId);
                studentGroup.Students.Add(student);
                student.StudentGroups.Add(studentGroup);
                studentGroupFacade.Update(studentGroup);
                userFacade.Update(student);
                return true;
            }
            return false;
        }
    }
}
