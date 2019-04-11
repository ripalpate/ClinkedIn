using ClinkedIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Data
{
    public class InterestRepository
    {
        static List<Interest> _interests = new List<Interest> {
            new Interest(1, "Watch Movies", 1),
            new Interest(2, "Play Soccer", 1),
            new Interest(3, "Karates", 1),
            new Interest(4, "Watch Movies", 2),
            new Interest(5, "Gardening", 3),
            new Interest(6, "Karates", 4),
            new Interest(7, "Karates", 5),
              new Interest(8, "Gardening", 2)
    };

        public List<Interest> AddInterest(string interestName, int userId)
        {
            var newInterest = new Interest(interestName, userId);

            newInterest.Id = _interests.Count + 1;

            _interests.Add(newInterest);

            return _interests;
        }
        public List<Interest> GetInterestsList(string interestName)
        {
           
            return _interests;
        }
        public List<Interest> GetAllInterestsList()
        {

            return _interests;
        }
    }
}
