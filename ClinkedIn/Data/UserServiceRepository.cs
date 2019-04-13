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
            new UserService (1,1,1),
            new UserService (2,1,2),
            new UserService (3,2,3),
            new UserService (4,3,4)
        };

        public List<UserService> GetUserServices()
        {
            return _userServices;
        }

        public UserService AddUserService(int id, int userid, int serviceid)
        {
            var newUserService = new UserService(id, userid, serviceid);

            _userServices.Add(newUserService);

            return newUserService;

        }


        public List<UserService> UpdateUserService()
        {
            return _userServices;
        }


        public List<UserService> DeleteUserService(int id)
        {
            var listOfUserServices = _userServices;

            var userServiceToBeRemoved = (from userService in listOfUserServices
                                      where (userService.Id == id)
                                      select userService).ToList();

            _userServices.Remove(userServiceToBeRemoved.First());

            var remainingUserServices = _userServices.ToList();

            return remainingUserServices;

        }

    }
}
