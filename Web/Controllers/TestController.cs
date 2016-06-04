using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL.Facades;
using BL.Services;
using Web.Models;
using Microsoft.AspNet.Identity;

namespace Web.Controllers
{
    [Authorize]
    public class TestController : Controller
    {
        private readonly TestFacade testFacade;
        private readonly UserFacade userFacade;
        private readonly TestService testService;

        public TestController(TestFacade testFacade, UserFacade userFacade, TestService testService)
        {
            this.testFacade = testFacade;
            this.userFacade = userFacade;
            this.testService = testService;
        }

        // GET: Test
        public ActionResult Index()
        {
            var testViewModel = new TestViewModel()
            {
                Tests = testFacade.ListAllForUser(Int32.Parse(User.Identity.GetUserId()))
            };
            return View(testViewModel);
        }

        // GET: Test/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Test/MakeTest/5
        public ActionResult MakeTest(int id)
        {
            var test = testService.MakeTest(Int32.Parse(User.Identity.GetUserId()), id);
            Dictionary<int, bool> answers = new Dictionary<int, bool>();
            foreach(var question in test.Questions.Keys)
            {
                foreach(var option in question.Options)
                {
                    answers.Add(option.Id, false);
                }
            }

            var testEditModel = new TestEditModel()
            {
                Test = test,
                Answers = answers
            };
            return View(testEditModel);
        }

        // POST: Test/MakeTest
        [HttpPost]
        public ActionResult MakeTest(TestEditModel model)
        {
            try
            {
                testService.EvaluateTest(model.Test, model.Answers);
                return RedirectToAction("../../Test");
            }
            catch
            {
                return View();
            }
        }
    }
}
