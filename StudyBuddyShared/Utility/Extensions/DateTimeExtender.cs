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
        public static string ToFullDate(this long TimeStamp, bool miliseconds = true)
        {
            if (miliseconds)
            {
                TimeStamp /= 1000;
            }
            return DateTimeOffset.FromUnixTimeSeconds(TimeStamp).LocalDateTime.ToFullDate();
        }
    }
}
