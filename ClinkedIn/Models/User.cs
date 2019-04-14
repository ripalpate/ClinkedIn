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
        public List<string> Interests { get; set; } = new List<string>();

        public User(string username, string password, string displayName, string offense)
            {
                Username = username;
                Password = password;
                DisplayName = displayName;
                Offense = offense;
            }

        public User(int id, string username, string password, string displayName, string offense)
        {
            Id = id;
            Username = username;
            Password = password;
            DisplayName = displayName;
            Offense = offense;
        }

        public User(int id, string userName, string displayName)
        {
            Id = id;
            Username = userName;
            DisplayName = displayName;
        }

        public User(string username, string offense, DateTime releaseDate, int id)
        {
            Id = id;
            Username = username;
            ReleaseDate = releaseDate;
            Offense = offense;
        }

        public User(List<string> interests)
        {
            Interests = interests;
        }
    }
}
