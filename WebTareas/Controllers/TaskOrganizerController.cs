using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTareas.Models;
using WebTareas.DAL;

namespace WebTareas.Controllers
{
    public class TaskOrganizerController : Controller
    {
        public IActionResult Index()
        {
            return View("TaskBoard");
        }

        public IActionResult NewTask(TaskInfo model)
        {
            using(TasksDataBaseContext context = new TasksDataBaseContext())
            {
                List<DAL.Task> taskList = context.Tasks.ToList();

                DAL.Task newTask = new DAL.Task
                {
                    Name = model.Name,
                    Description = model.Description,
                    Completed = false
                };

                taskList.Add(newTask);
                context.SaveChanges();
                model.Id = newTask.Id;
                
                if(model.Id != null) model.OngoingTasks.Add(newTask);
            }

            return View("TaskBoard", model);
        }
    }
}
