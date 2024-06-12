using Microsoft.EntityFrameworkCore;
using ToDoAPI.Models;

namespace ToDoAPI.Context
{
    public class ToDoItemContext:DbContext
    {
        public ToDoItemContext(DbContextOptions<ToDoItemContext> options) : base(options) { 
            
        }
        public DbSet<ToDoItem> ToDoItems { get; set; }
        public DbSet<Status> Statuses { get; set; }
    }
}
