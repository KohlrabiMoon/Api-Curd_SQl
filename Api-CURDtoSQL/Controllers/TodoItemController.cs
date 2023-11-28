using Api_CURDtoSQL.Data;
using Api_CURDtoSQL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_CURDtoSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        private readonly TodoContext _context;

        public TodoItemController(TodoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TodoItem>>> GetAllItemes()
        {
            var itemes = await _context.TodoItemes.ToListAsync();
            return Ok(itemes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetItem(int id)
        {
            var itemes = await _context.TodoItemes.FindAsync(id);
            if (itemes == null)
                return NotFound("Item not found");
            return Ok(itemes);
        }

        [HttpPost]
        public async Task<ActionResult<List<TodoItem>>> AddItem([FromBody]TodoItem item)
        {
            _context.TodoItemes.Add(item);
            await _context.SaveChangesAsync();

            return Ok(await _context.TodoItemes.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<TodoItem>>> UpdateItem(TodoItem updatedItem)
        {
            var dbItem = await _context.TodoItemes.FindAsync(updatedItem.Id);
            if (dbItem is null)
                return NotFound("Item not found");

            dbItem.Name = updatedItem.Name;
            dbItem.FirstName = updatedItem.FirstName;
            dbItem.LastName = updatedItem.LastName;
            dbItem.Price = updatedItem.Price;

            await _context.SaveChangesAsync();

            return Ok(await _context.TodoItemes.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<TodoItem>>> DeleteItem(int id)
        {
            var dbItem = await _context.TodoItemes.FindAsync(id);
            if (dbItem is null)
                return NotFound("Item not found");

            _context.TodoItemes.Remove(dbItem);
            await _context.SaveChangesAsync();

            return Ok(await _context.TodoItemes.ToListAsync());
        }

    }
}
