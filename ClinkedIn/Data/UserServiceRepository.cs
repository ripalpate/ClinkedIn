using ClinkedIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Data
{
    public class UserServiceRepository
    {
        public List<UserService> _userServices = new List<UserService>
        {
            new UserService (1,1),
            new UserService (2,1),
            new UserService (3,2),
            new UserService (4,3)
        };

        public List<UserService> GetUserServices()
        {
            return _userServices;
        }

        public UserService AddUserService(int id, int userid)
        {
            var newUserService = new UserService(id, userid);

            _userServices.Add(newUserService);

            return newUserService;

        }

    }
}
