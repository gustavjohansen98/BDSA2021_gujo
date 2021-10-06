using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Assignment4.Entities
{
    [Index(nameof(Email), IsUnique = true)] // from ef core package 
    public class User
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        public ICollection<Task> Tasks { get; set; } = new List<Task>();
    }
}
