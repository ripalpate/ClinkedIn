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
            var listOfUsers = _userRepository.GetAllUsers();
            var listOfInterests = _interestRepository.GetInterestsList(userId, interestName);
            var listOfFriendsWithSameInterest = listOfInterests.Where(interest => interest.InterestName.ToLower() == interestName.ToLower()).Where(interest => interest.UserId != userId).ToList();
            var FriendsThatUserCanMake = listOfUsers
                .Join(listOfFriendsWithSameInterest, 
                user => user.Id, 
                interest => interest.UserId,
                (user, interest) => new { user.Username, user.DisplayName, interest.InterestName });
            return Ok(FriendsThatUserCanMake);
        }

        //UPDATE interest
        [HttpPut]
        public ActionResult UpdateInterest(UpdateInterestRequest updateInterestRequest)
        {
            //filtering interest based on user id and interest Id.
            var updatedInterest = _interestRepository.UpdateInterest().Where(interest => interest.Id == updateInterestRequest.Id)
                .Where(interest => interest.UserId == updateInterestRequest.UserId).ToList();

            if (updatedInterest != null)
            {
                updatedInterest.First().InterestName = updateInterestRequest.InterestName;
            }
            else {
                return BadRequest(new { error = "users must have an interest name" });
            }
            return Accepted(updatedInterest);
        }

        //DELETE interest
        [HttpDelete("{id}/{userId}")]
        public ActionResult DeleteInterest(int id, int userId)
        {
            //var deleteInterest = _interestRepository.DeleteInterest(id, userId).Where(interest => interest.Id == id)
            //    .Where(interest => interest.UserId == userId).ToList();

            var interestsListAfterDeletion = _interestRepository.DeleteInterest(id, userId);
            return Accepted(interestsListAfterDeletion);
        }
    }
}