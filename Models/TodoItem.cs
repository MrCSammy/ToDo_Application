using System.ComponentModel.DataAnnotations;
using ToDo_Application.Models;

namespace ToDo_Application.Models
{
    public class TodoItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }
    }
}
