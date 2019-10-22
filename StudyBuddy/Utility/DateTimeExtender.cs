using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyBuddy
{
    public static class DateTimeExtender
    {
        public static string ToFullDate(this DateTime dateTime)
        {
            
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
