using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Models
{
    public class Interest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string InterestName { get; set; }

        public Interest(string interestName, int userId)
        {
            InterestName = interestName;
            UserId = userId;
        }

        public Interest(int id, string interestName, int userId)
        {
            Id = id;
            InterestName = interestName;
            UserId = userId;
        }
    }
}
