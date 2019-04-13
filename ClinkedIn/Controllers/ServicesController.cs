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
        //POST to add services
        public ActionResult AddService(CreateServiceRequest createRequest)
        {
            if (!_validator.Validate(createRequest))
            {
                return BadRequest(new { error = "users must have a name for their service and a cost" });
            }

            var newService = _serviceRepository.AddService(createRequest.Name, createRequest.Cost);

            return Created($"api/services/{newService.Id}", newService);
        }
        //GET all services
        [HttpGet("getServices")]

        public ActionResult getService(CreateServiceRequest createRequest)
        {
            var allServices = _serviceRepository.GetServices();
            
            return Ok(_serviceRepository.GetServices());
            
        }
        //GET services by name
        [HttpGet("getServicesByName")]

        public ActionResult getServiceByName(CreateServiceRequest createRequest)
        {
            var allServices = _serviceRepository.GetServices();

            var limitedServices = (from service in allServices
                                   where (service.Name == "cleaning")
                                   select service).ToList();

            return Ok(limitedServices);
        }

        //UPDATE service
        [HttpPut]
        public ActionResult UpdateService(UpdateServiceRequest updateServiceRequest)
        {
            //filtering service based on for user and service Id.
            var updatedService = _serviceRepository.UpdateService().Where(service => service.Id == updateServiceRequest.Id).Where(service => service.UserId == updateServiceRequest.UserId).ToList();

            if (updatedService != null)
            {
                updatedService.First().serviceName = updateServiceRequest.serviceName;
            }
            else
            {
                return BadRequest(new { error = "users must have an service name" });
            }


            return Accepted(updatedService);
        }

        //[HttpDelete("deleteService")]

    }
}