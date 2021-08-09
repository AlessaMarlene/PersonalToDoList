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
                //model.Attempts = 0
                TaskInfo modelBoard = new TaskInfo();

                using (TasksDataBaseContext context = new TasksDataBaseContext())
                {
                    foreach (DAL.Task task in context.Tasks)
                    {
                        if (!task.Completed) modelBoard.OngoingTasks.Add(task);
                        else modelBoard.CompletedTasks.Add(task);
                    }
                }

                return View("Views/TaskOrganizer/TaskBoard.cshtml", modelBoard);
            }

            model.Attempts ??= 0;

            if (model.Attempts == 3)
            {
                ModelState.AddModelError("MaximumAttempts", "You reached the maximum number of attempts.");
                model.Attempts = 0;
            }else model.Attempts++;

            ModelState.Remove("Attempts");

            return RedirectToAction("Controllers/TaskOrganizerController.cs", model);
        }
    }
}
