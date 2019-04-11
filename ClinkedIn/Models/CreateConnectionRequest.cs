using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Models
{
    public class CreateConnectionRequest
    {
     
        public int UserId1 { get; set; }
        public int UserId2 { get; set; }
        public bool IsFriend { get; set; }

    }
}
