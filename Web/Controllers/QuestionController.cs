using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL.Facades;
using Web.Models;
using BL.Services;

namespace Web.Controllers
{
    [Authorize]
    public class QuestionController : Controller
    {
        private readonly QuestionFacade questionFacade;
        private readonly OptionFacade optionFacade;
        private readonly TopicFacade topicFacade;
        private readonly QuestionOptionService questionOptionService;

        public QuestionController(QuestionFacade questionFacade,
                                  OptionFacade optionFacade,
                                  TopicFacade topicFacade,
                                  QuestionOptionService questionOptionService)
        {
            this.questionFacade = questionFacade;
            this.optionFacade = optionFacade;
            this.topicFacade = topicFacade;
            this.questionOptionService = questionOptionService;
        }

        // GET: Question
        [Authorize(Roles = "Teacher")]
        public ActionResult Index()
        {
            var questionViewModel = new QuestionViewModel()
            {
                Questions = questionFacade.ListAll()
            };
            return View(questionViewModel);
        }

        // GET: Question/Details/5
        [Authorize(Roles = "Teacher")]
        public ActionResult Details(int id)
        {
            var questionEditModel = new QuestionEditModel()
            {
                Question = questionFacade.FindById(id)
            };
            return View(questionEditModel);
        }

        // GET: Question/Create
        [Authorize(Roles = "Teacher")]
        public ActionResult Create()
        {
            var questionEditModel = new QuestionEditModel()
            {
                Topics = topicFacade.ListAll()
            };
            return View(questionEditModel);
        }

        // POST: Question/Create
        [Authorize(Roles = "Teacher")]
        [HttpPost]
        public ActionResult Create(QuestionEditModel model)
        {
            try
            {
                questionFacade.Create(model.Question, model.selectedTopic);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Question/Edit/5
        [Authorize(Roles = "Teacher")]
        public ActionResult Edit(int id)
        {
            var questionEditModel = new QuestionEditModel()
            {
                Question = questionFacade.FindById(id),
                Topics = topicFacade.ListAll()
            };
            return View(questionEditModel);
        }

        // POST: Question/Edit/5
        [Authorize(Roles = "Teacher")]
        [HttpPost]
        public ActionResult Edit(QuestionEditModel model)
        {
            try
            {
                questionFacade.Update(model.Question, model.selectedTopic);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Question/Delete/5
        [Authorize(Roles = "Teacher")]
        public ActionResult Delete(int id)
        {
            questionFacade.RemoveById(id);
            return RedirectToAction("Index");
        }

        // GET: Question/DeleteOption/5
        [Authorize(Roles = "Teacher")]
        public ActionResult DeleteOption(int id)
        {
            var option = optionFacade.FindById(id);
            int questionId = option.Question.Id;
            optionFacade.RemoveById(option.Id);
            return RedirectToAction("Details/" + questionId);
        }

        // GET: Question/AddOption/5
        [Authorize(Roles = "Teacher")]
        public ActionResult AddOption(int id)
        {
            var questionAddOptionModel = new QuestionAddOptionModel()
            {
                QuestionId = id
            };
            return View(questionAddOptionModel);
        }

        // POST: Question/AddOption/5
        [Authorize(Roles = "Teacher")]
        [HttpPost]
        public ActionResult AddOption(QuestionAddOptionModel model)
        {
            try
            {
                questionOptionService.AddOptionToQuestion(model.QuestionId, model.Option);
                return RedirectToAction("Details/" + model.QuestionId);
            }
            catch
            {
                return View();
            }
        }
    }
}
