using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TodoApp.Models;

namespace TodoApp.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base (options){}
        
        public DbSet<Task> Tasks { get; set; }

        internal TodoContext Where()
        {
            throw new NotImplementedException();
        }
    }
}
