using ChatRoom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ChatRoom.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ViewResult Login()
        {

            return View();
        }

        [HttpPost]
       
        [ActionName("Login")]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                // поиск пользователя в бд
                User user = null;
                using (UserContext db = new UserContext())
                {
                    user = db.Users.Where(u => u.Email == model.Name && u.Password == model.Password).FirstOrDefault();

                }
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Name, true);
                    return RedirectToAction("About", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                }
            }

            return View(model);
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
       
        [ActionName("Register")]
        public ActionResult Register(RegisterModel model, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                using (UserContext db = new UserContext())
                {
                    user = db.Users.Where(u => u.Email == model.Name && u.Password == model.Password ).FirstOrDefault();
                }
                if (user == null)
                {
                   
                    // создаем нового пользователя
                    using (UserContext db = new UserContext())
                    {
                       
                        db.Users.Add(new User { Email = model.Name, Password = model.Password, Age = model.Age});
                        db.SaveChanges();

                        user = db.Users.Where(u => u.Email == model.Name && u.Password == model.Password).FirstOrDefault();
                    }
                    // если пользователь удачно добавлен в бд
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Name, true);
                        return RedirectToAction("About", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                }
            }

            return View("Register");
        }
        [HttpPost]
        [ActionName("SignOut")]
        public ActionResult PostSignOut()
        {

            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}