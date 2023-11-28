using System.Data;
using Api_CURDtoSQL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api_CURDtoSQL.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext>options) : base(options)
        {

        }

        public DbSet<TodoItem> TodoItemes { get; set; }
    }
}
