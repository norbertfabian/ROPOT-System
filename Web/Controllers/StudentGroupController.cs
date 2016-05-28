using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using BL.Facades;
using BL.DTO;
using Microsoft.AspNet.Identity;
using BL.Services;

namespace Web.Controllers
{
    [Authorize]
    public class StudentGroupController : Controller
    {
        private readonly StudentGroupFacade studentGroupFacade;
        private readonly StudentGroupUserService studentGroupUserService;

        public StudentGroupController(StudentGroupFacade studentGroupFacade,
            StudentGroupUserService studentGroupUserService)
        {
            this.studentGroupFacade = studentGroupFacade;
            this.studentGroupUserService = studentGroupUserService;
        }

        // GET: StudentGroup
        [Authorize(Roles = "Teacher")]
        public ActionResult Index()
        {
            var studentGroupViewModel = new StudentGroupViewModel()
            {
                StudentGroups = studentGroupFacade.ListAll()
            };
            return View(studentGroupViewModel);
        }

        // GET: StudentGroup/Details/5
        [Authorize(Roles = "Teacher")]
        public ActionResult Details(int id)
        {
            var studentGroupViewModel = new StudentGroupEditModel()
            {
                StudentGroup = studentGroupFacade.FindById(id)
            };
            return View(studentGroupViewModel);
        }

        // GET: StudentGroup/Create
        [Authorize(Roles = "Teacher")]
        public ActionResult Create()
        {
            var studentGroupEditModel = new StudentGroupEditModel()
            {                
            };
            return View(studentGroupEditModel);
        }

        // POST: StudentGroup/Create
        [Authorize(Roles = "Teacher")]
        [HttpPost]
        public ActionResult Create(StudentGroupEditModel model)
        {
            try
            {
                studentGroupFacade.Create(model.StudentGroup);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentGroup/Edit/5
        [Authorize(Roles = "Teacher")]
        public ActionResult Edit(int id)
        {
            var studentGroupEditModel = new StudentGroupEditModel
            {
                StudentGroup = studentGroupFacade.FindById(id)
            };
            return View(studentGroupEditModel);
        }

        // POST: StudentGroup/Edit/5
        [Authorize(Roles = "Teacher")]
        [HttpPost]
        public ActionResult Edit(StudentGroupEditModel model)
        {
            try
            {
                studentGroupFacade.Update(model.StudentGroup);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentGroup/Delete/5
        [Authorize(Roles = "Teacher")]
        public ActionResult Delete(int id)
        {
            studentGroupFacade.RemoveById(id);
            return RedirectToAction("Index");
        }

        // GET: StudentGroup/JoinGroup
        public ActionResult JoinGroup()
        {
            var studentGroupUserModel = new StudentGroupUserModel()
            {
                Student = Int32.Parse(User.Identity.GetUserId()),
                StudentGroups = studentGroupFacade.ListAll()
            };
            return View(studentGroupUserModel);
        }

        // POST: StudentGroup/JoinGroup
        [HttpPost]
        public ActionResult JoinGroup(StudentGroupUserModel model)
        {
            if (studentGroupUserService.AddStudentToStudentGroupByCode(
            model.Student, model.Group, model.Code))
            { 
                return RedirectToAction("Index", "Profile");
            }
            model.Result = "Wrong code!";
            return View(model);
        }
    }
}
