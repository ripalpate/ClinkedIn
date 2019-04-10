using ClinkedIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Data
{
    public class ConnectionRepository
    {
        public static List<Connection> _connections = new List<Connection>
        {
           new Connection(1, 2, false, 1),
           new Connection(1, 3, true, 2),
           new Connection(2, 1, false, 3),
           new Connection(3, 2, false, 4),
           new Connection(2, 4, true, 5)
        };

        public Connection AddConnection(int userId1, int userId2, bool isFriend)
        {
            var newConnection = new Connection(userId1, userId2, isFriend);

            newConnection.Id = _connections.Count + 1;

            _connections.Add(newConnection);

            return newConnection;
        }
    }
}
