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
            var listOfConnections = _connectionRepository.GetAllConnectionsByUserId(userId);
            var listOfUsers = _userRepository.GetUsersById(userId);
            var enemyNames = new List<string>();

            var listOfMyEnemies = listOfConnections.Where(x => x.UserId1 == userId && !x.IsFriend)
                .Select(y => y.UserId2)
                .ToList();
            foreach(User user in listOfUsers)
            {
                foreach(int enemy in listOfMyEnemies)
                {
                    if(user.Id == enemy)
                    {
                        enemyNames.Add(user.Username);
                    }
                }
            }

            return Ok(enemyNames);
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