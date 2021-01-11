using Microsoft.AspNetCore.Mvc;
using TodoApp.Helpers;
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
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register([FromForm] Task task)
        {
            if (ModelState.IsValid)
            {
                if (DateHelper.VerifyDate(task))
                {
                    TempData["MSG_E"] = Message.MSG_E004;
                    return View();
                }
                _taskRepository.Register(task);
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
                if (DateHelper.VerifyDate(task))
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
    }
}
