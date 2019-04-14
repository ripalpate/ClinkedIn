using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Models
{
    public class Warden
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Warden(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
