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
            TaskInfo model = new TaskInfo();
            FillLists(model);

            return View("TaskBoard", model);
        }

        private void FillLists(TaskInfo model)
        {
            using (TasksDataBaseContext context = new TasksDataBaseContext())
            {
                List<DAL.Task> tasks = context.Tasks.ToList();

                foreach (DAL.Task task in tasks)
                {
                    if (!task.Completed) model.OngoingTasks.Add(task);
                    else model.CompletedTasks.Add(task);
                }
            }
        }

        public IActionResult NewTask(TaskInfo model)
        {
            FillLists(model);

            using (TasksDataBaseContext context = new TasksDataBaseContext())
            {
                DAL.Task newTask = new DAL.Task
                {
                    Name = model.Name,
                    Description = model.Description,
                    Completed = false
                };

                context.Tasks.Add(newTask);
                int changes = context.SaveChanges();
                model.Id = newTask.Id;
                
                if(changes > 0) model.OngoingTasks.Add(newTask);
            }

            return View("TaskBoard", model);
        }
    }
}
