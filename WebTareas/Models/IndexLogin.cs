using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebTareas.Models
{
    public class IndexLogin
    {
        public int? UserId { set; get; }

        [Required(ErrorMessage = "{0} name is required.")]
        [StringLength(10, ErrorMessage = "{0} must have {1} characters maximum.")]
        public string User { set; get; }

        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(8, ErrorMessage = "{0} must have {1} characters maximum.")]
        public string Password { set; get; }

        public int? Attempts { set; get; }
    }
}
