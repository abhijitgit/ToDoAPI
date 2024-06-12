namespace ToDoAPI.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; } = null;
        public DateOnly? DueDate { get; set; }
        public string? Category {  get; set; }
        public string? Priority { get; set; }
        public int StatusId {  get; set; }
        public Status? Status { get; }
    }
}
