using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TodoApp.Extensions;
using TodoApp.Libraries.Messages;
using TodoApp.Models;
using TodoApp.Repositories.Contracts;

namespace TodoApp.Controllers
{
    public class TaskController : Controller
    {
        private ITaskRepository _taskRepository;
       
        public TaskController(ITaskRepository taskController)
        {
            _taskRepository = taskController;
        }

        public IActionResult Index()
        {
            return View(_taskRepository.GetAllTasks());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] Task task)
        {
            if (ModelState.IsValid)
            {
                var taskDate = task.ConclusionDate;

                if (taskDate.VerifyDate())
                {
                    TempData["MSG_E"] = Message.MSG_E004;
                    return View();
                }

                _taskRepository.Create(task);
                TempData["MSG_S"] = Message.MSG_S001;

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var task = _taskRepository.GetTask(id);

            return View(task);
        }

        [HttpPost]
        public IActionResult Update([FromForm] Task task)
        {
            if (ModelState.IsValid)
            {
                var taskDate = task.ConclusionDate;

                if (taskDate.VerifyDate())
                {
                    TempData["MSG_E"] = Message.MSG_E004;
                    return View();
                }
                _taskRepository.Updade(task);
                TempData["MSG_S"] = Message.MSG_S001;

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Task task = _taskRepository.GetTask(id);

            return View(task);
        }
        
        public IActionResult IsDone(int id)
        {
            Task task = _taskRepository.GetTask(id);
            if (!task.IsDone)
            {
                task.IsDone = true;
            }

            _taskRepository.Updade(task);

            TempData["MSG_S"] = Message.MSG_S003;

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _taskRepository.Delete(id);

            TempData["MSG_S"] = Message.MSG_S002;

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult DeleteAllTasksConcluded()
        {
            var taskConcludedList = _taskRepository.GetAllConcludedTasks();

            if(taskConcludedList.Count <= 0 || taskConcludedList == null)
            {
                TempData["MSG_I"] = Message.MSG_I001;
            }
            else
            {
                _taskRepository.DeleteAll(taskConcludedList);
                TempData["MSG_S"] = Message.MSG_S002;
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult DeleteAll()
        {
            var allTasks = _taskRepository.GetAllTasks();

            if(allTasks.Count() <= 0 || allTasks == null)
            {
                TempData["MSG_I"] = Message.MSG_I001;
            }
            else
            {
                _taskRepository.DeleteAll(allTasks);
                TempData["MSG_S"] = Message.MSG_S002;
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult ConcludedAllTasks()
        {
            var allTasks = _taskRepository.GetAllTasks();

            if(allTasks.Count() <= 0 || allTasks == null)
            {
                TempData["MSG_I"] = Message.MSG_I002;
            }
            else
            {
                _taskRepository.ConcludedAllTasks(allTasks);
                TempData["MSG_S"] = Message.MSG_S001;
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
