using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebTareas.DAL
{
    public partial class Task
    {
        [Key]
        [Column("TaskID")]
        public int TaskId { get; set; }
        [Column("UserID")]
        public int UserId { get; set; }
        [Required]
        [StringLength(15)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        public bool Completed { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("Tasks")]
        public virtual User User { get; set; }
    }
}
