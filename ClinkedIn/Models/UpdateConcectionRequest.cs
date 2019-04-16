using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Models
{
    public class UpdateConcectionRequest
    {
        public int UserId1 { get; set; }
        public int UserId2 { get; set; }
        public bool IsFriend { get; set; }
        public int Id { get; set; }
    }
}
