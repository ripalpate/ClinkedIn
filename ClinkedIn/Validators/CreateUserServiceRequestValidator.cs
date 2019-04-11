using ClinkedIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Validators
{
    public class CreateUserServiceRequestValidator
    {
        public bool Validate(CreateUserServiceRequest requestToValidate)
        {
            return !(requestToValidate.Id == null
                || requestToValidate.UserId == null);
        }
    }
}
