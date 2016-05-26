using System.Web;
using System.Web.Mvc;
using BL.DTO;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Web.Models;
using BL.Facades;

namespace Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserFacade userFacade;

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public AccountController(UserFacade userFacade)
        {
            this.userFacade = userFacade;
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("/");
            }

            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var identity = userFacade.Login(model.Email, model.Password);

            if (identity != null)
            {
                AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, identity);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Bad Email or Password");
                return View(model);
            }
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new UserDTO
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    Password = model.Password,
                };
                userFacade.Register(user, model.Role);

                return RedirectToAction("Index", "Home");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }


        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }
    }
}