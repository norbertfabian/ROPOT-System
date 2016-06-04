using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Facades;
using BL.DTO;
using MoreLinq;

namespace BL.Services
{
    public class TestService
    {
        private readonly TopicQuestionService topicQuestionService;
        private readonly UserFacade userFacade;
        private readonly TestSchemeFacade testSchemeFacade;
        private readonly TestFacade testFacade;

        public TestService(TopicQuestionService topicQuestionService, 
                            UserFacade userFacade, 
                            TestSchemeFacade testSchemeFacade,
                            TestFacade testFacade)
        {
            this.topicQuestionService = topicQuestionService;
            this.userFacade = userFacade;
            this.testSchemeFacade = testSchemeFacade;
            this.testFacade = testFacade;
        }

        public void EvaluateTest(TestDTO test, Dictionary<int, bool> answers)
        {
            int points = 0;
            foreach(var question in test.Questions.Keys)
            {
                bool allCorrect = true;
                while(allCorrect)
                {
                    foreach(var option in question.Options)
                    {
                        if (option.Correct != answers[option.Id])
                            allCorrect = false;
                    }
                    test.Questions[question] = true;
                    points += question.Points;
                }
            }
            test.Score = points;
            testFacade.Create(test);
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
            questions = questions.DistinctBy(q => q.Id).ToList();
            Dictionary<QuestionDTO, bool> result = new Dictionary<QuestionDTO, bool>();
            foreach(var question in questions)
            {
                if (!result.Keys.Contains(question))
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
            if (testScheme.QuestionsAmount < allQuestions.Count)
            {
                Random rnd = new Random();
                for (int i = 0; i < testScheme.QuestionsAmount; i++)
                {
                    int r = rnd.Next(allQuestions.Count);
                    questions.Add(allQuestions[r]);
                    allQuestions.RemoveAt(r);
                    if (allQuestions.Count == 0)
                        break;
                }
            }
            else
            {
                questions.AddRange(allQuestions);
            }
            return questions;
        }
    }
}
