using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn.Data;
using ClinkedIn.Models;
using ClinkedIn.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinkedIn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConnectionController : ControllerBase
    {
        readonly ConnectionRepository _connectionRepository;
        readonly UserRepository _userRepository;
        readonly CreateConnectionRequestValidator _validator;

        public ConnectionController()
        {
            _connectionRepository = new ConnectionRepository();
            _userRepository = new UserRepository();
            _validator = new CreateConnectionRequestValidator();

        }

        [HttpGet("{userId}")]

        public ActionResult GetAllConnectionsByUserId(int userId)
        {
            var listOfConnections = _connectionRepository.GetAllConnectionsByUserId(userId);

            var listOfMyConnections = listOfConnections.Where(x => x.UserId1 == userId).ToList();

            return Ok(listOfMyConnections);
        }

        [HttpGet("enemies/{userId}")]

        public ActionResult GetMyEnemiesByUserId(int userId)
        {
            var connectionsById = _connectionRepository.GetAllConnectionsByUserId(userId);
            var allUsers = _userRepository.GetAllUsers();

            var myEnemies = connectionsById.Where(x => x.UserId1 == userId && !x.IsFriend)
                .Select(y => y.UserId2)
                .Join(allUsers,
                enemy => enemy,
                user => user.Id,
                (enemy, user) => new { user.Username, user.Offense, user.ReleaseDate, user.Id }
                )
                .ToList();

            return Ok(myEnemies);
        }

        [HttpGet("friends/{userId}")]

        public ActionResult GetMyFriendsByUserId(int userId)
        {
            var myConnections = _connectionRepository.GetAllConnectionsByUserId(userId);
            var allUsers = _userRepository.GetAllUsers();

            var myFriends = myConnections.Where(x => x.UserId1 == userId && x.IsFriend)
                .Select(y => y.UserId2)
                .Join(allUsers,
                friend => friend,
                user => user.Id,
                (friend, user) => new {user.Username, user.ReleaseDate, user.Offense, user.Id}
                )
                .ToList();

            return Ok(myFriends);
        }

        [HttpGet("friendsfriends/{userId}")]

        public ActionResult GetMyFriendsFriendsByUserId(int userId)
        {
            var myConnections = _connectionRepository.GetAllConnectionsByUserId(userId);
            var allUsers = _userRepository.GetAllUsers();
            var allConnections = _connectionRepository.GetAllConnections();
            var myFriendsFriends = new List<object>();

            var myFriends = myConnections.Where(connection => connection.UserId1 == userId && connection.IsFriend)
                .Select(friend => friend.UserId2)
                .Join(allUsers,
                friend => friend,
                user => user.Id,
                (friend, user) => new { user.Id }
                )
                .ToList();

            foreach(var id in myFriends)
            {
                var friendsConnections = _connectionRepository.GetAllConnectionsByUserId(id.Id);
                var myFriendsConnections = friendsConnections.Where(connection => connection.UserId1 == id.Id && connection.IsFriend)
                .Select(friend => friend.UserId2)
                .Join(allUsers,
                friend => friend,
                user => user.Id,
                (friend, user) => new { user.Id, user.Username, user.ReleaseDate, user.Offense }
                )
                .ToList();
                myFriendsFriends.Add(myFriendsConnections);
            }
            return Ok(myFriendsFriends);
        }

        [HttpPost()]

        public ActionResult AddConnection(CreateConnectionRequest createRequest)
        {
            if (!_validator.Validate(createRequest))
            {
                return BadRequest(new { error = "conections must have a userId1, userId2 and a 'isFriend' bool." });
            }

            var newConnection = _connectionRepository.AddConnection(createRequest.UserId1, createRequest.UserId2, createRequest.IsFriend);

            return Created($"api/connect/{newConnection.Id}", newConnection);
        }
    }
}