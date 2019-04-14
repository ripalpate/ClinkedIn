using ClinkedIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Data
{
    public class ConnectionRepository
    {
        UserRepository _userRepository = new UserRepository();

        public static List<Connection> _connections = new List<Connection>
        {
            new Connection(1, 2, true, 1),
            new Connection(1, 3, true, 2),
            new Connection(2, 1, false, 3),
            new Connection(3, 2, false, 4),
            new Connection(2, 4, true, 5),
            new Connection(3, 4, true, 6),
            new Connection(1, 4, true, 7),
            new Connection(4, 2, true, 8),
        };

        public static List<Connection> _myConnections = new List<Connection>();
        public static List<Connection> _friendsConnections = new List<Connection>();

        public Connection AddConnection(int userId1, int userId2, bool isFriend)
        {
            var newConnection = new Connection(userId1, userId2, isFriend);

            newConnection.Id = _connections.Count + 1;

            _connections.Add(newConnection);

            return newConnection;
        }

        public List<Connection> GetAllConnectionsByUserId(int userId)
        {
           var myConnections = _connections.Where(x => x.UserId1 == userId).ToList();

            return myConnections;
        }

        public List<User> GetMyEnemiesByUserId(int userId)
        {
            var myConnections = GetAllConnectionsByUserId(userId);
            var allUsers = _userRepository.GetAllUsers();

            var myEnemies = myConnections.Where(x => x.UserId1 == userId && !x.IsFriend)
                .Select(y => y.UserId2)
                .Join(allUsers,
                enemy => enemy,
                user => user.Id,
                (enemy, user) => new User (user.Username, user.Offense, user.ReleaseDate, user.Id)
                )
                .ToList();

            return myEnemies;
        }

        public List<User> GetMyFriendsByUserId(int userId)
        {
            var myConnections = GetAllConnectionsByUserId(userId);
            var allUsers = _userRepository.GetAllUsers();

            var myFriends = myConnections.Where(x => x.UserId1 == userId && x.IsFriend)
                .Select(y => y.UserId2)
                .Join(allUsers,
                friend => friend,
                user => user.Id,
                (enemy, user) => new User(user.Username, user.Offense, user.ReleaseDate, user.Id)
                )
                .ToList();

            return myFriends;
        }

        public List<User> GetMyFriendsFriendsByUserId(int userId)
        {
            var myFriends = GetMyFriendsByUserId(userId);
            var allUsers = _userRepository.GetAllUsers();
            var myFriendsFriends = new List<User>();

            foreach (var id in myFriends)
            {
                var connections = GetAllConnectionsByUserId(id.Id);
                var myFriendsFriend = connections.Where(connection => connection.UserId1 == id.Id && userId != connection.UserId2 && connection.IsFriend)
                .Select(friend => friend.UserId2)
                .Join(allUsers,
                friend => friend,
                user => user.Id,
                (friend, user) => new User(user.Username, user.Offense, user.ReleaseDate, user.Id)
                )
                .SingleOrDefault();
                var friendExistsNot = myFriendsFriends.Any(f => f.Id == myFriendsFriend.Id);
                if (!friendExistsNot)
                {
                    myFriendsFriends.Add(myFriendsFriend);
                }
            }
            return myFriendsFriends;
        }

        public List<Connection> GetAllConnections()
        {
            return _connections;
        }

        public List<Connection> GetFriendsConnectionsByUserId(int userId)
        {
            return _friendsConnections;
        }

        public List<Connection> DeleteConnection(int id, int userId)
        {
            var connectionToDelete = _connections.Where(connection => connection.Id == id).ToList();
            var connections = _connections.Remove(connectionToDelete.First());
            return _connections;
        }

        public List<Connection> EditConnection(int userId1, int userId2, bool isFriend, int id)
        {
            var connectionToEdit = _connections.Where(connection => connection.Id == id).ToList();
            connectionToEdit.First().IsFriend = isFriend;
    
            return connectionToEdit;
        }
    }
}
