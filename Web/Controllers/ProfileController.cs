using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using BL.Facades;
using BL.DTO;
using Microsoft.AspNet.Identity;

namespace Web.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserFacade userFacade;

        public ProfileController(UserFacade userFacade)
        {
            this.userFacade = userFacade;
        }

        // GET: Profile
        public ActionResult Index()
        {
            var userDto = userFacade.FindById(Int32.Parse(User.Identity.GetUserId()));
            var userProfileModel = new UserProfileModel()
            {
                User = userDto
            };
            return View(userProfileModel);
        }

        // GET: Profile/Edit/5
        public ActionResult Edit(int id)
        {
            var userDto = userFacade.FindById(id);
            var userProfileModel = new UserProfileModel()
            {
                User = userDto
            };
            return View(userProfileModel);
        }

        // POST: Profile/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UserProfileModel model)
        {
            try
            {
                userFacade.Update(model.User);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
