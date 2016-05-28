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
        public ActionResult Index()
        {
            var questionViewModel = new QuestionViewModel()
            {
                Questions = questionFacade.ListAll()
            };
            return View(questionViewModel);
        }

        // GET: Question/Details/5
        public ActionResult Details(int id)
        {
            var questionEditModel = new QuestionEditModel()
            {
                Question = questionFacade.FindById(id)
            };
            return View(questionEditModel);
        }

        // GET: Question/Create
        public ActionResult Create()
        {
            var questionEditModel = new QuestionEditModel()
            {
                Topics = topicFacade.ListAll()
            };
            return View(questionEditModel);
        }

        // POST: Question/Create
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
        public ActionResult Delete(int id)
        {
            questionFacade.RemoveById(id);
            return RedirectToAction("Index");
        }

        // GET: Question/AddOption/5
        public ActionResult AddOption(int id)
        {
            var questionAddOptionModel = new QuestionAddOptionModel()
            {
                QuestionId = id
            };
            return View(questionAddOptionModel);
        }

        // POST: Question/AddOption/5
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
