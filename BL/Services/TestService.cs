using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Facades;
using BL.DTO;

namespace BL.Services
{
    public class TestService
    {
        private readonly TopicQuestionService topicQuestionService;
        private readonly UserFacade userFacade;
        private readonly TestSchemeFacade testSchemeFacade;

        public TestService(TopicQuestionService topicQuestionService, 
                            UserFacade userFacade, 
                            TestSchemeFacade testSchemeFacade)
        {
            this.topicQuestionService = topicQuestionService;
            this.userFacade = userFacade;
            this.testSchemeFacade = testSchemeFacade;
        }

        public TestDTO MakeTest(int userId, int testSchemeId)
        {
            TestDTO test = new TestDTO()
            {
                User = userFacade.FindById(userId),
                TestScheme = testSchemeFacade.FindById(testSchemeId),
                Questions = GetFalseQuestionsForTest(testSchemeId)
            };
            test.MaxPoints = test.Questions.Sum(q => q.Key.Points);
            test.Score = 0;
            return test;
        }
        
        private Dictionary<QuestionDTO, bool> GetFalseQuestionsForTest(int testSchemeId)
        {
            var questions = GetQuestionsForTest(testSchemeId);
            Dictionary<QuestionDTO, bool> result = new Dictionary<QuestionDTO, bool>();
            foreach(var question in questions)
            {
                result.Add(question, false);
            }
            return result;
        }

        private List<QuestionDTO> GetQuestionsForTest(int testSchemeId)
        {
            List<QuestionDTO> questions = new List<QuestionDTO>();
            var testScheme = testSchemeFacade.FindById(testSchemeId);
            var allQuestions = topicQuestionService.GetQuestionsForTopics(
                testScheme.Topics.Select(t => t.Id).ToList());

            for(int i = 0; i < testScheme.QuestionsAmount; i++) { 
                Random rnd = new Random();
                int r = rnd.Next(allQuestions.Count);
                questions.Add(allQuestions[r]);
            }

            return questions;
        }
    }
}
