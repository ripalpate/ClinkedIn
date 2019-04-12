using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Models
{
    public class UpdateInterestRequest
    {
        public int Id { get; set; }
        public string InterestName { get; set; }
        public int UserId { get; set; }
    }
}
