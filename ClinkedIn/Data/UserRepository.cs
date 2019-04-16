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
            new User(5, "Marco Crank", "abc", "mc", "prostitution", new DateTime(2019, 12, 25, 00, 00, 00))
        };

        public User AddUser(string username, string password, string displayName, string offense, DateTime releaseDate)
        {
            var newUser = new User(username, password, displayName, offense, releaseDate);

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
            var _user = _users.Where(x => x.Id == userId).ToList();
            {

            }
            foreach (User user in _user)
            {
                var timeLeft = GetTimeLeft(user.ReleaseDate);
                user.TimeLeft = timeLeft;
            }
            return _user;
        }

        public TimeSpan GetTimeLeft(DateTime releaseDate)
        {
            var timeLeft = releaseDate.Subtract(DateTime.Now);

            return timeLeft;
        }

        public List<User> UpdateUser(int userId, string userName, string password, string displayName, string offense, int wallet)
        {
            var updatedUser = _users
                .Where(user => user.Id == userId).ToList();

            updatedUser.First().Username = userName;
            updatedUser.First().Password = password;
            updatedUser.First().DisplayName = displayName;
            updatedUser.First().Offense = offense;
            updatedUser.First().Wallet = wallet;
            return updatedUser;
        }
    }
}
