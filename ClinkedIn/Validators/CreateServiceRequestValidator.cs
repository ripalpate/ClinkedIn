using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn.Models;

namespace ClinkedIn.Validators
{
    public class CreateServiceRequestValidator
    {
        public bool Validate(CreateServiceRequest requestToValidate)
        {            
            return !(string.IsNullOrEmpty(requestToValidate.Name));
        }

    }
}
