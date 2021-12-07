using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UsersManager.Entities;

namespace UsersManager.Common
{
    public static class UsersCollection
    {
        private static readonly ICollection<User> data;
        private static int counter = 1;

        static UsersCollection()
        {
            data = new List<User>();

            User item = null;

            item = new User();
            item.Username = "nikiv";
            item.Password = "nikipass";
            item.FirstName = "Nikola";
            item.LastName = "Valchanov";
            AddUser(item);

            item = new User();
            item.Username = "gefrix";
            item.Password = "mitkopass";
            item.FirstName = "Dimitar";
            item.LastName = "Blagoev";
            AddUser(item);
        }

        public static ICollection<User> GetUsers()
        {
            return data;
        }

        public static void AddUser(User user)
        {
            user.Id = counter++;
            data.Add(user);
        }
    }
}