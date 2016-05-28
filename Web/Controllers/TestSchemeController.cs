using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL.DTO;
using BL.Facades;
using Web.Models;
using BL.Services;
using Microsoft.AspNet.Identity;

namespace Web.Controllers
{
    [Authorize]
    public class TestSchemeController : Controller
    {
        private readonly TestSchemeFacade testSchemeFacade;
        private readonly StudentGroupFacade studentGroupFacade;
        private readonly TopicFacade topicFacade;
        private readonly StudentGroupTestSchemeService studentGroupTestSchemeService;
        private readonly UserFacade userFacade;

        public TestSchemeController(TestSchemeFacade testSchemeFacade, 
                                    StudentGroupFacade studentGroupFacade, 
                                    TopicFacade topicFacade,
                                    StudentGroupTestSchemeService studentGroupTestSchemeService,
                                    UserFacade userFacade)
        {
            this.testSchemeFacade = testSchemeFacade;
            this.studentGroupFacade = studentGroupFacade;
            this.topicFacade = topicFacade;
            this.studentGroupTestSchemeService = studentGroupTestSchemeService;
            this.userFacade = userFacade;
        }

        // GET: TestScheme
        [Authorize(Roles = "Teacher")]
        public ActionResult Index()
        {
            var testSchemeViewModel = new TestSchemeViewModel()
            {
                TestSchemes = testSchemeFacade.ListAll()
            };
            return View(testSchemeViewModel);
        }

        // GET: TestScheme/Details/5
        [Authorize(Roles = "Teacher")]
        public ActionResult Details(int id)
        {
            var testSchemeEditModel = new TestSchemeEditModel()
            {
                TestScheme = testSchemeFacade.FindById(id)
            };
            return View(testSchemeEditModel);
        }

        // GET: TestScheme/Create
        [Authorize(Roles = "Teacher")]
        public ActionResult Create()
        {
            var testSchemeEditModel = new TestSchemeEditModel()
            {
                StudentGroups = studentGroupFacade.ListAll(),
                Topics = topicFacade.ListAll()
            };
            return View(testSchemeEditModel);
        }

        // POST: TestScheme/Create
        [Authorize(Roles = "Teacher")]
        [HttpPost]
        public ActionResult Create(TestSchemeEditModel model)
        {
            try
            {
                testSchemeFacade.Create(model.TestScheme, model.SelectedTopics, model.SelectedStudentGroups);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TestScheme/Edit/5
        [Authorize(Roles = "Teacher")]
        public ActionResult Edit(int id)
        {
            var testSchemeEditModel = new TestSchemeEditModel
            {
                TestScheme = testSchemeFacade.FindById(id),
                StudentGroups = studentGroupFacade.ListAll(),
                Topics = topicFacade.ListAll()
            };
            return View(testSchemeEditModel);
        }

        // POST: TestScheme/Edit/5
        [Authorize(Roles = "Teacher")]
        [HttpPost]
        public ActionResult Edit(TestSchemeEditModel model)
        {
            try
            {
                testSchemeFacade.Update(model.TestScheme);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TestScheme/Delete/5
        [Authorize(Roles = "Teacher")]
        public ActionResult Delete(int id)
        {
            testSchemeFacade.RemoveById(id);
            return RedirectToAction("Index");
        }

        public ActionResult MyTests()
        {
            var userDto = userFacade.FindById(Int32.Parse(User.Identity.GetUserId()));
            var myTestViewModel = new MyTestsViewModel()
            {
                Tests = studentGroupTestSchemeService.getAllTestSchemesForStudentGroups(
                    userDto.StudentGroups.Select(sg => sg.Id).ToList())
            };
            return View(myTestViewModel);
        }
    }
}
