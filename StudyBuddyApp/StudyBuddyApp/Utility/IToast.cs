using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyApp.Utility
{
    // Interface for use with DependencyService
    public interface IToast
    {
        void LongToast(string message);
        void ShortToast(string message);
    }
}
