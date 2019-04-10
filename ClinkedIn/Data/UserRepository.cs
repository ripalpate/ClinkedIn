using ClinkedIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Data
{
    public class UserRepository
    {
        static List<User> _users = new List<User>();

        public User AddUser(string username, string password, string displayName)
        {
            var newUser = new User(username, password, displayName);

            newUser.Id = _users.Count + 1;

            _users.Add(newUser);

            return newUser;
        }
    }
}
