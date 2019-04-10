using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Models
{
    public class Connection
    {
        public int Id;
        public int UserId1;
        public int UserId2;
        public bool IsFriend;

        public Connection(int userId1, int userId2, bool isFriend)
        {
            UserId1 = userId1;
            UserId2 = userId2;
            IsFriend = isFriend;
        }
    }
}
