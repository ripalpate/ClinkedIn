﻿using System;
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
            var _user = _userRepository.GetUsersById(userId);

            return Ok(_user);
        } 

        [HttpPost("register")]

        public ActionResult AddUser(CreateUserRequest createRequest)
        {
            if (!_validator.Validate(createRequest))
            {
                return BadRequest(new { error = "users must have a username, password and display name" });
            }

            var newUser = _userRepository.AddUser(createRequest.Username, createRequest.Password, createRequest.DisplayName, createRequest.Offense, createRequest.ReleaseDate);

            return Created($"api/users/{newUser.Id}", newUser);
        }

        [HttpPut]
        public ActionResult UpdateUser(UpdateUserRequest updateUserRequest)
        {
            if (updateUserRequest == null)
            {
                return BadRequest(new { error = "Please provide necessary information" });
            }
            var updatedUser = _userRepository.UpdateUser(
                updateUserRequest.Id, 
                updateUserRequest.UserName, 
                updateUserRequest.Password,
                updateUserRequest.DisplayName,
                updateUserRequest.Offense,
                updateUserRequest.Wallet);
            return Ok(updatedUser);
        }
    }
}