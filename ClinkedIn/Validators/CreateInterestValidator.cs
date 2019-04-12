using ClinkedIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Validators
{
    public class CreateInterestValidator
    {
        public bool ValidateInterest(CreateInterestRequest request)
        {
            return !string.IsNullOrEmpty(request.InterestName);
        }
    }
}
