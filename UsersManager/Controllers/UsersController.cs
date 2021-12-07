using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UsersManager.Common;
using UsersManager.Entities;

namespace UsersManager.Controllers
{
    public class UsersController : Controller
    {
        public ICollection<User> items = UsersCollection.GetUsers();

        public ActionResult Index()
        {
            return View(items);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Add", "Users");
            }

            User user = items.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return RedirectToAction("Index", "Users");
            }

            ViewBag["Type"] = "Edit";
            return View("CreateOrEdit", user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                return this.Edit(user.Id);
            }

            User oldUser = items.First(u => u.Id == user.Id);
            items.Remove(oldUser);
            items.Add(user);

            return RedirectToAction("Index", "Users");
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag["Type"] = "Add";
            return View("CreateOrEdit");
        }

        [HttpPost]
        public ActionResult Add(User user)
        {
            if (ModelState.IsValid)
            {
                UsersCollection.AddUser(user);
                return RedirectToAction("Index", "Users");
            }

            return this.Add();
        }
    }
}