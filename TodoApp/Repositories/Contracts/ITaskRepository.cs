using System.Collections.Generic;
using TodoApp.Models;

namespace TodoApp.Repositories.Contracts
{
    public interface ITaskRepository
    {
        void Register(Task task);

        void Updade(Task task);

        Task GetTask(int id);

        void ConcludedAllTasks(IEnumerable<Task> tasks);

        List<Task> GetAllConcludedTasks();

        void Delete(int id);

        IEnumerable<Task> GetAllTasks();
        
        void DeleteAll(IEnumerable<Task> allTasks);
    }
}
