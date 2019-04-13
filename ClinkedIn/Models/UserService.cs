using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Models
{
    public class UserService
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ServiceId { get; set; }

        public UserService(int id, int userid, int serviceid)
        {
            Id = id;
            UserId = userid;
            ServiceId = serviceid;
        }
    }
}
