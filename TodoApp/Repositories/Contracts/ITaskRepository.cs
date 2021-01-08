using System;
using System.Collections.Generic;
using System.Linq;
using TodoApp.Models;

namespace TodoApp.Repositories.Contracts
{
    public interface ITaskRepository
    {
        //CRUD
        void Register(Task task);
        void Updade(Task task);
        Task GetTask(int id);
        void Delete(int id);
        IEnumerable<Task> GetAllTasks();
    }
}
