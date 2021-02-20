using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using week_06.DatabaseHelper;

namespace week_06.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly TodoContext _context;

        public ToDoController(TodoContext context)
        {
            _context = context;
        }

        // GetAll() is automatically recognized as
        // http://localhost:<port #>/api/todo
        [HttpGet]
        public IEnumerable<ToDo> GetAll()
        {
            var res = _context.ToDos.ToList();
            return res;
        }

        // GetById() is automatically recognized as
        // http://localhost:<port #>/api/todo/{id}
        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(long id)
        {
            var item = _context.ToDos.FirstOrDefault(t => t.Id == id);
            if (item == null) return NotFound();
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ToDo todo)
        {
            // additional param checks etc..
            if (todo.Description == null || todo.Description == "") return BadRequest();
            
            _context.ToDos.Add(todo);
            _context.SaveChanges();
            return new ObjectResult(todo);
        }

        [HttpPut]
        [Route("MyEdit")] // Custom route
        public IActionResult GetByParams([FromBody] ToDo todo)
        {
            var item = _context.ToDos.Where(t => t.Id == todo.Id).FirstOrDefault();
            if (item == null) return NotFound();
            else
            {
                item.IsComplete = todo.IsComplete;
                _context.SaveChanges();
            }
            return new ObjectResult(item);
        }

        [HttpDelete("{id}")]
        public IActionResult MyDelete(int id)
        {
            var item = _context.ToDos.Where(t => t.Id == id).FirstOrDefault();
            if (item == null) return NotFound();
            _context.ToDos.Remove(item);
            _context.SaveChanges();
            return new ObjectResult(item);
        }

        [HttpGet]
        [Route("Don")]
        public IActionResult GetMessage(string firstName, string lastName)
        {
            string message = $"Hi {firstName} {lastName}. It is {DateTime.Now}.";
            dynamic dynamicObj = new { FirstName = firstName, LastName = lastName, Message = message };
            return new ObjectResult(dynamicObj);
        }
    }
}
