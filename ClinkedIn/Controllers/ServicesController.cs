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
    public class ServicesController : ControllerBase
    {
        readonly ServiceRepository _serviceRepository;
        readonly CreateServiceRequestValidator _validator;
        public ServicesController()
        {
            _validator = new CreateServiceRequestValidator();
            _serviceRepository = new ServiceRepository();

        }

        [HttpPost("service")]

        public ActionResult AddService(CreateServiceRequest createRequest)
        {
            if (!_validator.Validate(createRequest))
            {
                return BadRequest(new { error = "users must have a name for their service and a cost" });
            }

            var newService = _serviceRepository.AddService(createRequest.Name, createRequest.Cost);

            return Created($"api/services/{newService.Id}", newService);
        }

        [HttpGet("getServices")]

        public ActionResult getService(CreateServiceRequest createRequest)
        {
            var allServices = _serviceRepository.GetServices();
            
            return Ok(_serviceRepository.GetServices());
            
        }

        [HttpGet("getServicesByName")]

        public ActionResult getServiceByName(CreateServiceRequest createRequest)
        {
            var allServices = _serviceRepository.GetServices();

            var limitedServices = (from service in allServices
                                   where (service.Name == "cleaning")
                                   select service).ToList();

            return Ok(limitedServices);
        }

    }
}