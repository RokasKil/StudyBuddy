using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyBuddy.Entity
{
    public class User
    {
        //Fill this as we go along;
        public string firstName;
        public string lastName;
        public string username;
        public string profilePictureLocation;
        public bool gender;
        public int KarmaPoints { get; set; }
        public bool IsLecturer { get; set; } = false;
        public delegate void onUpdate(User user);
        public onUpdate OnUpdate;
    }
}
