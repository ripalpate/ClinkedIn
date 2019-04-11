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
            var listOfInterestWithSameUserId = newInterestList.Where(x => x.UserId == createRequest.UserId).ToList();
            return Created($"api/{listOfInterestWithSameUserId}", listOfInterestWithSameUserId);
        }

        [HttpGet("getInterests")]
        public ActionResult getAllInterest()
        {
            var listOfInterests = _interestRepository.GetAllInterestsList();
            //  var listOfFriendsWithSameInterest = listOfInterests.Where(interest => interest.InterestName == "Watch Movies").ToList();
            //return Ok(listOfFriendsWithSameInterest);
            return Ok(listOfInterests);
        }

        [HttpGet("getInterests/{interestName}")]
        public ActionResult getUsersBySameInterest(string interestName)
        {
            var listOfInterests = _interestRepository.GetInterestsList(interestName);
            var listOfFriendsWithSameInterest = listOfInterests.Where(interest => interest.InterestName == interestName).ToList();
            //var listofFriendsWithSameInterest =  listOfInterests.GroupBy(x => x)
            //                 .Where(g => g.Count() > 1)
            //                 .Select(g => g.Key)
            //                 .ToList();
            return Ok(listOfFriendsWithSameInterest);
            //return Ok(listOfInterests);
        }
    }
}