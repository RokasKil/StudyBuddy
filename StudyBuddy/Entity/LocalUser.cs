using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyBuddy.Entity
{
     public class LocalUser : User
    {
        public string privateKey;
        public bool Advise { get; set; } = false;
        public LocalUser()
        {
            
        }
    }
}
