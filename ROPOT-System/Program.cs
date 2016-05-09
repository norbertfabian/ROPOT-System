using BL.Facades;
using BL.DTO;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROPOT_System
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Printing out created test question:");
            QuestionFacade questionFacade = new QuestionFacade();
            questionFacade.Create(CreateQuestionDto());

            foreach (var item in questionFacade.ListAll())
            {
                Console.WriteLine("Question: " + item.Description);
                Console.WriteLine("Topic: " + item.Topic.Name);
                Console.WriteLine("Options:");
                foreach (var option in item.Options)
                {
                    Console.WriteLine("* " + option.Text);
                }
            }

            Console.ReadKey();
        }
        private static QuestionDTO CreateQuestionDto()
        {
            QuestionDTO question = new QuestionDTO() { Description = "Option" };
            TopicDTO topic = new TopicDTO() { Name = "Name" };
            OptionDTO option1 = new OptionDTO() { Text = "option1" };
            OptionDTO option2 = new OptionDTO() { Text = "option2" };

            question.Topic = topic;
            question.Options.Add(option1);
            question.Options.Add(option2);

            return question;
        }
    }
}
