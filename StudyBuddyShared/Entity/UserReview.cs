using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyBuddy.Entity
{
    public class UserReview
    {
        public string Message { get; set; }
        public int Karma { get; set; }
        public string Username { get; set; }
        public DateTime PostDate { get; set; }
    }
}
