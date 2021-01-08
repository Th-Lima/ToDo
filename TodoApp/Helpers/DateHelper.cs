using System;
using TodoApp.Libraries.Messages;
using TodoApp.Models;

namespace TodoApp.Helpers
{
    public class DateHelper 
    {
        public static bool VerifyDate(Task task)
        {
            if (task.ConclusionDate < DateTime.Today)
            {
                return true;
            }

            return false;
        }
    }
}
