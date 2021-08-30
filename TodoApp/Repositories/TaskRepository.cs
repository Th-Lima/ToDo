using System.Collections.Generic;
using System.Linq;
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

        public void DeleteConcludedTasks()
        {
            var tasks = GetAllConcludedTasks();

            foreach (var task in tasks)
            {
                _db.Remove(task);
            }

            _db.SaveChanges();
        }

        public List<Task> GetAllConcludedTasks()
        {
            return _db.Tasks.Where(x => x.IsDone == true).ToList();
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
