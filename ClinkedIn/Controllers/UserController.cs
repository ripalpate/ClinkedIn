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
    public class UserController : ControllerBase
    {
        readonly UserRepository _userRepository;
        readonly CreateUserRequestValidator _validator;
        public UserController()
        {
            _validator = new CreateUserRequestValidator();
            _userRepository = new UserRepository();

        }

        [HttpGet]

        public ActionResult GetAllUsers()
        {
            var listOfUsers = _userRepository.GetAllUsers();

            return Ok(listOfUsers);
        }

        [HttpGet("{userId}")]

        public ActionResult GetUsersById(int userId)
        {
            var user = _userRepository.GetUsersById(userId);

            return Ok(user);
        } 

        [HttpPost("register")]

        public ActionResult AddUser(CreateUserRequest createRequest)
        {
            if (!_validator.Validate(createRequest))
            {
                return BadRequest(new { error = "users must have a username, password and display name" });
            }

            var newUser = _userRepository.AddUser(createRequest.Username, createRequest.Password, createRequest.DisplayName, createRequest.Offense);

            return Created($"api/users/{newUser.Id}", newUser);
        }
    }
}