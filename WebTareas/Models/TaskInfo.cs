using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WebTareas.DAL;

namespace WebTareas.Models
{
    public class TaskInfo
    {
        public int? Id { set; get; }

        [Required(ErrorMessage = "A {0} is required")]
        [StringLength(15, ErrorMessage = "{0} must have {1} characters maximum.")]
        public string Name { set; get; }

        [Required(ErrorMessage = "A {0} is required")]
        [StringLength(50, ErrorMessage = "{0} must have {1} characters maximum.")]
        public string Description { set; get; }

        public List<DAL.Task> OngoingTasks { set; get; }

        public List<DAL.Task> CompletedTasks { set; get; }

        public TaskInfo()
        {
            this.OngoingTasks = new List<DAL.Task>();
            this.CompletedTasks = new List<DAL.Task>();
        }
    }
}
