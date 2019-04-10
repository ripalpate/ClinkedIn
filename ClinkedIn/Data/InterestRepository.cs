using ClinkedIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Data
{
    public class InterestRepository
    {
        static List<Interest> _interests = new List<Interest>();
        public List<Interest> AddInterest(string interestName, int userId)
        {
            var newInterest = new Interest(interestName, userId);

            newInterest.Id = _interests.Count + 1;

            _interests.Add(newInterest);

            return _interests;
        }
        public List<Interest> GetInterestsList()
        {
            return _interests;
        }
    }
}
