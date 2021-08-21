using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebTareas.Models;
using WebTareas.DAL;

namespace WebTareas.Controllers
{
    public class HomeController : Controller
    {                                                                                                                                                                                                                                          
        public IActionResult Index()
        {
            return View("IndexLogin");
        }

        [HttpPost]
        public IActionResult Login(IndexLogin model)
        {
            if (ModelState.IsValid)
            {
                int id = FindUser(model);

                return RedirectToAction("Index", "TaskOrganizer", new { UserID = id });
            }

            model.Attempts ??= 0;

            if (model.Attempts == 3)
            {
                ModelState.AddModelError("MaximumAttempts", "You reached the maximum number of attempts.");
                model.Attempts = 0;
            }else model.Attempts++;

            ModelState.Remove("Attempts");

            return View("IndexLogin", model);
        }

        private int FindUser(IndexLogin model)
        {
            int id = 0;

            using (TasksDataBaseContext context = new TasksDataBaseContext())
            {
                List<User> users = context.Users.ToList();
                User user = context.Users.FirstOrDefault(u => u.UserName == model.User);

                if (user == null)
                {
                    User newUser = new User
                    {
                        UserName = model.User,
                        Password = model.Password
                    };

                    context.Users.Add(newUser);
                    context.SaveChanges();
                    id = newUser.UserId;
                }
                else id = user.UserId;
            }

            return id;
        }
    }
}
