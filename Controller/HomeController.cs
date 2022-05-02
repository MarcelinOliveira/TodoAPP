using Microsoft.AspNetCore.Mvc;
using TodoAPP.Data;
using TodoAPP.Models;

namespace TodoAPP.Controller
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("/")]
        public IActionResult Get
        (
            [FromServices]
            AppDbContext context
        )
        {
            return Ok(context.Todos.ToList());
        }

        [HttpGet("/{id:int}")]
        public IActionResult GetById
        (
            [FromRoute] int id,
            [FromServices] AppDbContext context
        )
        {
            var todo = context.Todos.FirstOrDefault(x => x.id == id);
            if (todo == null)
                return NotFound();

            return Ok(todo);
        }

        [HttpPost("/")]
        public IActionResult Post
          (
              [FromBody] TodoModel todo,
              [FromServices] AppDbContext context
          )
        {
            context.Todos.Add(todo);
            context.SaveChanges();
            return Ok(context.Todos.ToList());
        }

        [HttpPut("/{id:int}")]
        public IActionResult Put
        (
                [FromRoute] int id,
                [FromBody] TodoModel todo,
                [FromServices] AppDbContext context
        )
        {
            var model = context.Todos.FirstOrDefault(x => x.id == id);
            if (model == null)
                return NotFound();

            model.Done = todo.Done;
            model.Title = todo.Title;

            context.Todos.Update(model);
            context.SaveChanges();
            return Ok(model);
        }

        [HttpDelete("/Delete/{id:int}")]
        public IActionResult Delete
        (
                [FromRoute] int id,
                [FromServices] AppDbContext context
        )
        {
            var model = context.Todos.FirstOrDefault(x => x.id == id);
            if (model == null)
                return NotFound("There's no Model to delete");

            context.Todos.Remove(model);
            context.SaveChanges();
            return Ok("Delete Sucessfulll");
        }
    }
}