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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string ProfilePictureLocation { get; set; }
        public bool Gender { get; set; }
        public int KarmaPoints { get; set; }
        public bool IsLecturer { get; set; } = false;
        public delegate void OnUpdate(User user);
        public OnUpdate OnUpdateHandler;
    }
}
