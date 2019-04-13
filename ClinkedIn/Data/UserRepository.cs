using ClinkedIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Data
{
    public class UserRepository
    {
        static List<User> _users = new List<User>
        {
            new User(1, "Shane Wilson", "abc", "sdw", "murder", new DateTime(2020, 01, 15, 00, 00, 00)),
            new User(2, "Rob Rice", "abc", "rr", "being too hot", new DateTime(2025, 05, 15, 00, 00, 00)),
            new User(3, "Ripal Patel", "abc", "rp", "evil genius", new DateTime(2022, 06, 4, 00, 00, 00)),
            new User(4, "Wayne Collier", "abc", "wc", "unlawful possession of firearm", new DateTime(2021, 01, 15, 00, 00, 00)),
            new User(5, "Marco Crank", "abc", "sdw", "prostitution", new DateTime(2019, 12, 25, 00, 00, 00))
        };

        public User AddUser(string username, string password, string displayName, string offense)
        {
            var newUser = new User(username, password, displayName, offense);

            newUser.Id = _users.Count + 1;

            _users.Add(newUser);

            return newUser;
        }

        public List<User> GetAllUsers()
        {

            foreach (User user in _users)
            {
                var timeLeft = GetTimeLeft(user.ReleaseDate);
                user.TimeLeft = timeLeft;
            }
            return _users;
        }

        public List<User> GetUsersById(int userId)
        {
            return _users;
        }

        public TimeSpan GetTimeLeft(DateTime releaseDate)
        {
            var timeLeft = releaseDate.Subtract(DateTime.Now);

            return timeLeft;
        }
    }
}
