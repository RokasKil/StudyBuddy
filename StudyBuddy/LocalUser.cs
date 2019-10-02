using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyBuddy
{
     public class LocalUser : User
    {
        public string localKey;
        public bool Advise { get; set; } = false;
        public LocalUser()
        {
            karmaPoints = 100;
            //Will have to probably take this from the database or
            //KarmaHandler class
        }

    }
}
