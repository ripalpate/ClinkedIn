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
            new User(1, "Shane Wilson", "abc", "sdw", "murder"),
            new User(2, "Rob Rice", "abc", "rr", "being too hot"),
            new User(3, "Ripal Patel", "abc", "rp", "evil genius"),
            new User(4, "Wayne Collier", "abc", "wc", "unlawful possession of firearm"),
            new User(5, "Marco Crank", "abc", "sdw", "prostitution")
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
            return _users;
        }

        public List<User> GetUsersById(int userId)
        {
            return _users;
        }
    }
}
