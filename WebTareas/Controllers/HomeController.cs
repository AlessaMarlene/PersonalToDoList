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
                return RedirectToAction("Index", "TaskOrganizer");
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
    }
}
