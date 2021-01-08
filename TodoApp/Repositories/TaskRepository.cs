using System.Collections.Generic;
using TodoApp.Data;
using TodoApp.Models;
using TodoApp.Repositories.Contracts;

namespace TodoApp.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private TodoContext _db;
        public TaskRepository(TodoContext db)
        {
            _db = db;
        }

        public void Register(Task task)
        {
            _db.Add(task);
            _db.SaveChanges();
        }

        public void Updade(Task task)
        {
            _db.Update(task);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            Task task = GetTask(id);
            _db.Remove(task);
            _db.SaveChanges();
        }

        public Task GetTask(int id)
        {
            return _db.Tasks.Find(id);
        }

        public IEnumerable<Task> GetAllTasks()
        {
            return _db.Tasks;
        }
    }
}
