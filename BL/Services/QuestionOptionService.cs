using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Facades;
using BL.DTO;
using DAL.Entities;

namespace BL.Services
{
    public class QuestionOptionService
    {
        private readonly QuestionFacade questionFacade;
        private readonly OptionFacade optionFacade;

        public QuestionOptionService(QuestionFacade questionFacade, OptionFacade optionFacade)
        {
            this.questionFacade = questionFacade;
            this.optionFacade = optionFacade;
        }

        public void AddOptionToQuestion(int questionId, OptionDTO option)
        {
            var question = questionFacade.FindById(questionId);
            option.Question = question;
            question.Options.Add(option);
            question.OneCorrectType = HasOneCorrectOption(question);
            optionFacade.Create(option);
            questionFacade.Update(question);
        }

        public bool HasOneCorrectOption(QuestionDTO question)
        {
            int correctCount = 0;
            foreach(var option in question.Options)
            {
                if (option.Correct)
                    correctCount++;
            }
            return correctCount == 1;
        }
    }
}
