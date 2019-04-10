using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Wallet { get; set; }
        public string Offense { get; set; }

        public User(string username, string password, string displayName, DateTime releaseDate, int wallet, string offense)
            {
                Username = username;
                Password = password;
                DisplayName = displayName;
                ReleaseDate = releaseDate;
                Wallet = wallet;
                Offense = offense;
            }
    }
}
