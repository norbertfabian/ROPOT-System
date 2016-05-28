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
    public class TopicQuestionService
    {
        private readonly TopicFacade topicFacade;
        private readonly QuestionFacade questionFacade;

        public TopicQuestionService(TopicFacade topicFacade, QuestionFacade questionFacade)
        {
            this.topicFacade = topicFacade;
            this.questionFacade = questionFacade;
        }

        public List<QuestionDTO> GetQuestionsForTopics(List<int> topicIds)
        {
            var questions = new List<QuestionDTO>();
            foreach(var topicId in topicIds)
            {
                questions.AddRange(GetQuestionsForTopic(topicId));
            }
            questions.DistinctBy(q => q.Id);
            return questions;
        }

        private List<QuestionDTO> GetQuestionsForTopic(int topicId)
        {
            var questions = new List<QuestionDTO>();
            questions.AddRange(questionFacade.ListAll().Where(q => q.Topic.Id == topicId).ToList());
            var topic = topicFacade.FindById(topicId);
            if (topic.Childs.Count > 0)
            {
                foreach(var childTopic in topic.Childs)
                {
                    questions.AddRange(GetQuestionsForTopic(childTopic.Id));
                }
            }
            return questions;
        }
    }
}
