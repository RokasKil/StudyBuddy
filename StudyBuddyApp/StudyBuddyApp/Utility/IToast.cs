using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyApp.Utility
{
    public interface IToast
    {
        void LongToast(string message);
        void ShortToast(string message);
    }
}
