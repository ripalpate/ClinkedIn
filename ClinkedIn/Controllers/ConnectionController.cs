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

        [HttpGet()]

        public ActionResult GetAllConnections()
        {
            var allConnections = _connectionRepository.GetAllConnections();

            return Ok(allConnections);
        }

        [HttpGet("{userId}")]

        public ActionResult GetAllConnectionsByUserId(int userId)
        {
            var myConnections = _connectionRepository.GetAllConnectionsByUserId(userId);

            return Ok(myConnections);
        }

        [HttpGet("enemies/{userId}")]

        public ActionResult GetMyEnemiesByUserId(int userId)
        {
            var myEnemies = _connectionRepository.GetMyEnemiesByUserId(userId);

            return Ok(myEnemies);
        }

        [HttpGet("friends/{userId}")]

        public ActionResult GetMyFriendsByUserId(int userId)
        {
            var myFriends = _connectionRepository.GetMyFriendsByUserId(userId);

            return Ok(myFriends);
        }

        [HttpGet("friendsfriends/{userId}")]

        public ActionResult GetMyFriendsFriendsByUserId(int userId)
        {
            var myFriendsFriends = _connectionRepository.GetMyFriendsFriendsByUserId(userId);

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

        [HttpDelete("{id}")]

        public ActionResult DeleteConnection(int id, int userId)
        {
            var connections = _connectionRepository.DeleteConnection(id, userId);

            return Ok(connections);
        }

        [HttpPut("{id}")]

        public ActionResult EditConnection(UpdateConcectionRequest connectionToEdit, int id)
        {
            var editedConnection = _connectionRepository.EditConnection(connectionToEdit.UserId1, 
                                                                    connectionToEdit.UserId2,
                                                                    connectionToEdit.IsFriend,
                                                                    connectionToEdit.Id);

            return Ok();
        }
    }
}