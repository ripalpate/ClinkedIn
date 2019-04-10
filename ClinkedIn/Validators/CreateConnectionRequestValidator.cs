using ClinkedIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Validators
{
    public class CreateConnectionRequestValidator
    {
        public bool Validate(CreateConnectionRequest requestToValidate)

        {
            return !(requestToValidate.UserId1 == null
                || (requestToValidate.UserId2 == null)
                || (requestToValidate.IsFriend == null));
        }
    }
}
