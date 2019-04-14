using ClinkedIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Validators
{
    public class CreateWardenRequestValidator
    {
        public bool Validate(CreateWardenRequest requestToValidate)
        {
            return !(string.IsNullOrEmpty(requestToValidate.Username)
                || string.IsNullOrEmpty(requestToValidate.Password));
        }
    }
}
