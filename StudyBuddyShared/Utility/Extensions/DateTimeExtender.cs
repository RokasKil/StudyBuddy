using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.Utility.Extensions
{
    public static class DateTimeExtender
    {
        public static string ToFullDate(this DateTime dateTime)
        {

            return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
