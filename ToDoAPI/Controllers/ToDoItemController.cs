using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Models;
using ToDoAPI.Context;

namespace ToDoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemController : ControllerBase
    {
        private readonly ToDoItemContext _todoContext;
        public ToDoItemController(ToDoItemContext context)
        {
            _todoContext = context;
        }
        [HttpGet]
        public ActionResult<ToDoItem> GetToDoItems()
        {
            return Ok(_todoContext.ToDoItems.ToList());
        }

        [HttpGet("{dueDate}")]
        public ActionResult<ToDoItem> GetToDoItemsByDueDate(DateOnly dueDate)
        {
            var todoList = _todoContext.ToDoItems.Where(
                todo => todo.DueDate == dueDate
            );

            return Ok(todoList);
        }

        [HttpPost]
        public ActionResult CreateToDo(ToDoItem newToDo)
        {
            _todoContext.ToDoItems.Add(newToDo);
            _todoContext.SaveChanges();

            return Ok(newToDo);
        }

        [HttpPut("{todoId}")]
        public ActionResult UpdateToDo(int todoId, ToDoItem toDo)
        {
            var todoItem = _todoContext.ToDoItems.Where(todo => todo.Id == todoId).FirstOrDefault();
            if (todoItem == null)
            {
                return BadRequest();
            }
            todoItem.Name = toDo.Name;
            todoItem.Description = toDo.Description;
            todoItem.DueDate = toDo.DueDate;
            todoItem.StatusId = toDo.StatusId;
            todoItem.CategoryId = toDo.CategoryId;
            todoItem.Priority = toDo.Priority;

            _todoContext.ToDoItems.Update(todoItem);
            _todoContext.SaveChanges();
            return Ok(todoItem);
        }

        [HttpDelete("{todoId}")]
        public ActionResult DeleteToDo(int todoId)
        {
            var todoItem = _todoContext.ToDoItems.Where(todo => todo.Id == todoId).FirstOrDefault();
            if (todoItem == null)
            {
                return BadRequest();
            }
            _todoContext.ToDoItems.Remove(todoItem);
            _todoContext.SaveChanges();
            return Ok(todoItem);
        }
    }
}
