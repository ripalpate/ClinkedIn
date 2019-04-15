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
    public class WardenController : ControllerBase
    {
        readonly WardenRepository _wardenRepository;
        readonly CreateWardenRequestValidator _validator;
        public WardenController()
        {
            _validator = new CreateWardenRequestValidator();
            _wardenRepository = new WardenRepository();

        }

        [HttpPost("register")]

        public ActionResult AddWarden(CreateWardenRequest createRequest)
        {
            if (!_validator.Validate(createRequest))
            {
                return BadRequest(new { error = "warden must have a username and password" });
            }

            var newWarden = _wardenRepository.AddWarden(createRequest.Username, createRequest.Password);

            return Created($"api/warden/{newWarden.Id}", newWarden);
        }

        [HttpGet("users")]

        public ActionResult AllUsers()
        {
            var users = _wardenRepository.GetAllUsers();
            return Ok(users);
        }
    }
}