using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Assignment4.Core;

namespace Assignment4.Entities
{
    public class Task
    {   
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        public int? AssignedTo { get; set; } // id foreign key to User entity (should be optional)

        public string? Description { get; set; } 

        [Required]
        [Column(TypeName = "nvarchar(24)")] // then we don't have to specify the string conversion override in OnModelCreating
        public State State { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }
}
