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
    public class InterestsController : ControllerBase
    {
        readonly InterestRepository _interestRepository;
        readonly CreateInterestValidator _validator;
        public InterestsController()
        {
            _validator = new CreateInterestValidator();
            _interestRepository = new InterestRepository();

        }

        [HttpPost]

        public ActionResult AddInterest(CreateInterestRequest createRequest)
        {
            if (!_validator.ValidateInterest(createRequest))
            {
                return BadRequest(new { error = "users must have an interest name" });
            }

            var newInterestList = _interestRepository.AddInterest(createRequest.InterestName, createRequest.UserId);
            var listOfSimilarUserId = newInterestList.Where(x => x.UserId == createRequest.UserId).ToList();
            return Created($"api/{listOfSimilarUserId}", listOfSimilarUserId);
        }

        [HttpGet("getInterests")]
        public ActionResult getUsersBySameInterest()
        {
            var listOfInterests = _interestRepository.GetInterestsList();
            return Ok($"api/{listOfInterests}");
        }
    }
}