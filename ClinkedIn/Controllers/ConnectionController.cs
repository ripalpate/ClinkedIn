using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn.Data;
using ClinkedIn.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinkedIn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConnectionController : ControllerBase
    {
        readonly ConnectionRepository _connectionRepository;

       public ConnectionController()
        {
            _connectionRepository = new ConnectionRepository();
        }

        [HttpPost("connect")]

        public ActionResult AddConnection(Connection connection)
        {
            var newConnection = _connectionRepository.AddConnection(connection.UserId1, connection.UserId2, connection.IsFriend);

            return Created($"api/connect/{newConnection.Id}", newConnection);
        }
    }
}