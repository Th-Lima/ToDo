using System;

namespace TodoApp.Extensions
{
    public static class DateTimeExtension 
    {
        public static bool VerifyDate(this DateTime date)
        {
            if (date.Date < DateTime.Now.Date)
            {
                return true;
            }

            return false;
        }
    }
}
