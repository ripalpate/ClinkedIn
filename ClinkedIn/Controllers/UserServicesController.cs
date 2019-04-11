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
    public class UserServicesController : ControllerBase
    {
        readonly UserServiceRepository _userServiceRepository;
        readonly CreateUserServiceRequestValidator _validator;
        public UserServicesController()
        {
            _validator = new CreateUserServiceRequestValidator();
            _userServiceRepository = new UserServiceRepository();

        }

        [HttpPost("userService")]

        public ActionResult AddUserService(CreateUserServiceRequest createRequest)
        {
            if (!_validator.Validate(createRequest))
            {
                return BadRequest(new { error = "userServices must have an id and a userId" });
            }

            var newUserService = _userServiceRepository.AddUserService(createRequest.Id, createRequest.UserId);

            return Created($"api/userServices/{newUserService.Id}", newUserService);
        }

        [HttpGet("getUserServices")]

        public ActionResult getUserService(CreateUserServiceRequest createRequest)
        {
            var allServices = _userServiceRepository.GetUserServices();

            return Ok(_userServiceRepository.GetUserServices());

        }

        [HttpGet("getUserServicesByName")]

        public ActionResult getUserServiceByName(CreateUserServiceRequest createRequest)
        {
            var allUserServices = _userServiceRepository.GetUserServices();

            var limitedUserServices = (from service in allUserServices
                                   where (service.UserId == 2)
                                   select service).ToList();

            return Ok(limitedUserServices);
        }

    }
}