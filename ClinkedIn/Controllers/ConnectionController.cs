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
       readonly CreateConnectionRequestValidator _validator;

        public ConnectionController()
        {
            _connectionRepository = new ConnectionRepository();
            _validator = new CreateConnectionRequestValidator();

        }

        //[HttpPost("connect")]

        //public ActionResult AddConnection(Connection connection)
        //{
        //    var newConnection = _connectionRepository.AddConnection(connection.UserId1, connection.UserId2, connection.IsFriend);

        //    return Created($"api/connect/{newConnection.Id}", newConnection);
        //}

        [HttpPost("connect")]

        public ActionResult AddConnection(CreateConnectionRequest createRequest)
        {
            if (!_validator.Validate(createRequest))
            {
                return BadRequest(new { error = "conectionss must have a userId1, userId2 and a 'isFriend' bool." });
            }

            var newConnection = _connectionRepository.AddConnection(createRequest.UserId1, createRequest.UserId2, createRequest.IsFriend);

            return Created($"api/connect/{newConnection.Id}", newConnection);
        }
    }
}