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
        public IActionResult Index(int UserID)
        {
            TaskInfo model = new TaskInfo { UserId = UserID };
            FillLists(model);

            return View("TaskBoard", model);
        }

        private void FillLists(TaskInfo model)
        {
            using (TasksDataBaseContext context = new TasksDataBaseContext())
            {
                List<DAL.Task> tasks = context.Tasks.Where(u => u.UserId == model.UserId).ToList();

                foreach (DAL.Task task in tasks)
                {
                    if (!task.Completed) model.OngoingTasks.Add(task);
                    else model.CompletedTasks.Add(task);
                }
            }
        }

        [HttpPost]
        public IActionResult PersistTask(TaskInfo model, string addButton)
        {
            if (ModelState.IsValid)
            {
                using (TasksDataBaseContext context = new TasksDataBaseContext())
                {
                    if (!string.IsNullOrEmpty(addButton))
                    {
                        if (!context.Tasks.Any(t => t.Name == model.Name))
                        {
                            DAL.Task newTask = new DAL.Task
                            {
                                UserId = model.UserId,
                                Name = model.Name,
                                Description = model.Description,
                                Completed = false
                            };

                            context.Tasks.Add(newTask);
                            context.SaveChanges();
                            model.Id = newTask.TaskId;
                        }
                        else ModelState.AddModelError("TaskName", "The name of the task already exists.");
                    }
                    else
                    {
                        DAL.Task newTask = context.Tasks.Find(model.Id);
                        newTask.Name = model.Name;
                        newTask.Description = model.Description;
                        context.SaveChanges();
                    }
                }
            }

            FillLists(model);

            return View("TaskBoard", model);
        }

        public IActionResult MarkCompleted(int TaskID)
        {
            TaskInfo model = new TaskInfo();

            using(TasksDataBaseContext context = new TasksDataBaseContext())
            {
                DAL.Task task = context.Tasks.Find(TaskID);
                task.Completed = true;
                context.SaveChanges();
                model.UserId = task.UserId;
                FillLists(model);
            }

            return View("TaskBoard", model);
        }

        public IActionResult DeleteTask(int TaskID)
        {
            TaskInfo model = new TaskInfo();

            using(TasksDataBaseContext context = new TasksDataBaseContext())
            {
                DAL.Task task = context.Tasks.Find(TaskID);
                context.Tasks.Remove(task);
                context.SaveChanges();
                model.UserId = task.UserId;
                FillLists(model);
            }

            return View("TaskBoard", model);
        }

        public IActionResult SelectTask(int TaskID)
        {
            TaskInfo model;

            using (TasksDataBaseContext context = new TasksDataBaseContext())
            {
                DAL.Task task = context.Tasks.Find(TaskID);
                model = new TaskInfo
                {
                    Id = TaskID,
                    UserId = task.UserId,
                    Name = task.Name,
                    Description = task.Description
                };
                FillLists(model);
            }
            TempData["ShowButton"] = "Show";
            
            return View("TaskBoard", model);
        }

        public IActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
