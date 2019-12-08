using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyApp.Utility
{   
    //For checking if app is in background
    public interface IBackgroundChecker
    {
        bool IsInBackground();
    }
}
