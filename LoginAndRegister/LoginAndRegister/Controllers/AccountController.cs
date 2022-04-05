using LoginAndRegister.Data.DataContext;
using LoginAndRegister.Data.Entity;
using LoginAndRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Security;

namespace LoginAndRegister.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(new LoginVM());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Login(LoginVM request)
        {
            using (var _db = new DataContext())
            {
                var user = _db.Users.FirstOrDefault(x => x.Email == request.Email && x.Password == request.Password);
                if (user != null)
                {
                    FormsAuthenticationConfiguration conf = new FormsAuthenticationConfiguration();
                    conf.Timeout = DateTime.Now.AddMonths(1) - DateTime.Now;
                    FormsAuthentication.SetAuthCookie(user.FirstName, request.IsPersist);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("InvalidUser", "Kullanıcıadı ve şifre hatalı!...");
                }
            }
            return View(request);
        }

        [HttpGet]
        public ActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(new RegisterVM());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Register(RegisterVM request)
        {
            using (var _db = new DataContext())
            {
                if (request.Password == request.PasswordVerify)
                {
                    var user = new ApplicationUser()
                    {
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        Email = request.Email,
                        Password = request.Password,
                    };
                    _db.Users.Add(user);
                    _db.SaveChanges();
                    FormsAuthenticationConfiguration conf = new FormsAuthenticationConfiguration();
                    conf.Timeout = DateTime.Now.AddMonths(1) - DateTime.Now;
                    FormsAuthentication.SetAuthCookie(user.FirstName,true);
                }
                else
                {
                    ModelState.AddModelError("Invalidpasswords", "parolalar farklı");
                }
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}