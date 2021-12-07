using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UsersManager.Common;

namespace UsersManager.Controllers
{
    public class HomeController : Controller
    {
        const string loggedUser = "loggedUser";

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (Session[loggedUser] != null)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewData["username"] = username;

            bool isValid = true;

            if (username == "")
            {
                isValid = false;
                ViewData["usernameError"] = "This field is Required!";
            }

            if (password == "")
            {
                isValid = false;
                ViewData["passwordError"] = "This field is Required!";
            }

            if (isValid == false)
                return View();

            if (UsersCollection.GetUsers().Any(u => u.Username == username && u.Password == password))
            {
                Session[loggedUser] = username;
            }

            if (Session[loggedUser] == null)
            {
                isValid = false;
                ViewData["authenticationError"] = "Authentication failed!";
            }

            if (isValid == false)
                return View();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            Session[loggedUser] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}