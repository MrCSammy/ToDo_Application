namespace ToDo_Application.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
