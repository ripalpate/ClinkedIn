using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Models
{
    public class CreateInterestRequest
    {
        public string InterestName { get; set; }
        public int UserId { get; set; }
    }
}
