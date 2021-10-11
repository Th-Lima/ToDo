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

        /// <summary>
        /// Obtém todas as tarefas concluídas do banco
        /// </summary>
        /// <returns></returns>
        public List<Task> GetAllConcludedTasks()
        {
            return _db.Tasks.Where(x => x.IsDone == true).ToList();
        }

        /// <summary>
        /// Obtém uma tarefa pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task GetTask(int id)
        {
            return _db.Tasks.Find(id);
        }

        /// <summary>
        /// Obtém todas as taks do banco
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Task> GetAllTasks()
        {
            return _db.Tasks;
        }

        /// <summary>
        /// Cadastra uma task no banco
        /// </summary>
        /// <param name="task"></param>
        public void Register(Task task)
        {
            _db.Add(task);
            _db.SaveChanges();
        }

        /// <summary>
        /// Atualiza uma task no banco
        /// </summary>
        /// <param name="task"></param>
        public void Updade(Task task)
        {
            _db.Update(task);
            _db.SaveChanges();
        }

        /// <summary>
        /// Deleta uma task do banco
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            Task task = GetTask(id);
            _db.Remove(task);
            _db.SaveChanges();
        }

        /// <summary>
        /// Delete todas as tarefas do banco
        /// </summary>
        /// <param name="allTasks"></param>
        public void DeleteAll(IEnumerable<Task> allTasks)
        {
            if(allTasks != null)
            {
                foreach (var task in allTasks)
                {
                    this.Delete(task.Id);
                }
            }
        }

        /// <summary>
        /// Defini como concluída todas as tarefas do banco
        /// </summary>
        /// <param name="tasks"></param>
        public void ConcludedAllTasks(IEnumerable<Task> tasks)
        {
            if (tasks != null)
            {
                foreach (var task in tasks)
                {
                    task.IsDone = true;

                    this.Updade(task);
                }
            }
        }
    }
}
