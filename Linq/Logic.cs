using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyBuddyShared.Entity;


namespace Linq
{
    public class Logic
    {
        public Logic()
        {
            var merged = (from vartotojai in users
                         join zinutes in messages on vartotojai.Username equals zinutes.Username
                         select new { Name = vartotojai.FirstName + " " + vartotojai.LastName, zinutes.Text, zinutes.Id }).ToList();
            foreach(var x in merged)
            {
                Console.WriteLine(x.Id + " " + x.Name + " " + x.Text);
            }

            var avgKarmaPoints = users.Average(s => s.KarmaPoints);
            Console.WriteLine("Average Karma pts of users: {0}", avgKarmaPoints);

        }
        List<Message> messages = new List<Message>()
        {
            new Message() { Id = 1, Username = "dog1", Text = "Sveiki, JJ" },
            new Message() { Id = 2, Username = "cat1", Text = "Labas, PJ" },
            new Message() { Id = 3, Username = "dog2", Text = "Taip, JP" },
            new Message() { Id = 4, Username = "cat2", Text = "Ne, PP" }
        };
        List<User> users = new List<User>()
        {
            new User() { FirstName = "Jonas", LastName = "Jonainis", Username = "dog1", KarmaPoints = 11 },
            new User() { FirstName = "Petras", LastName = "Jonainis", Username = "cat1", KarmaPoints = 22 },
            new User() { FirstName = "Jonas", LastName = "Petraitis", Username = "dog2", KarmaPoints = 33 },
            new User() { FirstName = "Petras", LastName = "Petraitis", Username = "cat2", KarmaPoints = 34 }
        };
        
    }
}
