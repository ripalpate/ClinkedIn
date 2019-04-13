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
        readonly UserRepository _userRepository;
        readonly CreateInterestValidator _validator;

        public InterestsController()
        {
            _validator = new CreateInterestValidator();
            _interestRepository = new InterestRepository();
            _userRepository = new UserRepository();
        }
        //GET user with all interests.
        [HttpGet("{userId}")]

        //CREAT interests for users.
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

        //GET users with same interests.
        [HttpGet("getInterests/{userId}/{interestName}")]
        public ActionResult getUsersBySameInterest( int userId, string interestName)
        {
            var listOfFriendsWithSameInterest = _interestRepository.GetInterestsList(userId, interestName);
            return Ok(listOfFriendsWithSameInterest);
        }

        //UPDATE interest
        [HttpPut]
        public ActionResult UpdateInterest(UpdateInterestRequest updateInterestRequest)
        {
            if (updateInterestRequest == null)
            {
                return BadRequest(new { error = "users must have an interest name" });
            }
            var updatedInterest = _interestRepository.UpdateInterest(updateInterestRequest.Id, updateInterestRequest.UserId, updateInterestRequest.InterestName);
            return Ok(updatedInterest);
        }

        //DELETE interest
        [HttpDelete("{id}/{userId}")]
        public ActionResult DeleteInterest(int id, int userId)
        { 
            var interestsListAfterDeletion = _interestRepository.DeleteInterest(id, userId);
            return Ok(interestsListAfterDeletion);
        }
    }
}