using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebTareas.DAL
{
    public partial class User
    {
        public User()
        {
            Tasks = new HashSet<Task>();
        }

        [Key]
        [Column("UserID")]
        public int UserId { get; set; }
        [Required]
        [StringLength(10)]
        public string UserName { get; set; }
        [Required]
        [StringLength(8)]
        public string Password { get; set; }

        [InverseProperty(nameof(Task.User))]
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
