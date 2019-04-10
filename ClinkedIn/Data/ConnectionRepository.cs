using ClinkedIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Data
{
    public class ConnectionRepository
    {
        static List<Connection> _connections = new List<Connection>();

        public Connection AddConnection(int userId1, int userId2, bool isFriend)
        {
            var newConnection = new Connection(userId1, userId2, isFriend);

            newConnection.Id = _connections.Count + 1;

            _connections.Add(newConnection);

            return newConnection;
        }
    }
}
