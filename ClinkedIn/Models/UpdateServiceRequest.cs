using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Models
{
    public class UpdateServiceRequest
    {        
           public int Id { get; set; }
           public string Name { get; set; }
           public double Cost { get; set; }       
    }
}
