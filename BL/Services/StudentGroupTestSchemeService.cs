using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Facades;
using BL.DTO;

namespace BL.Services
{
    public class StudentGroupTestSchemeService
    {
        private readonly StudentGroupFacade studentGroupFacade;
        private readonly TestSchemeFacade testSchemeFacade;

        public StudentGroupTestSchemeService(StudentGroupFacade studentGroupFacade, 
                                            TestSchemeFacade testSchemeFacade)
        {
            this.testSchemeFacade = testSchemeFacade;
            this.studentGroupFacade = studentGroupFacade;
        }

        public List<TestSchemeDTO> getAllTestSchemesForStudentGroups(List<int> groupIds)
        {
            var testSchemes = testSchemeFacade.ListAll();
            var result = new List<TestSchemeDTO>();
            foreach(var testScheme in testSchemes)
            {
                if (testScheme.Groups.Select(g => g.Id).ToList().Any(i => groupIds.Contains(i)))
                {
                    result.Add(testScheme);
                }
            }
            return result;
        }
    }
}
