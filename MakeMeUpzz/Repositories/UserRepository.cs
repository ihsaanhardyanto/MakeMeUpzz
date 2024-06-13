using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Repository
{
    public class UserRepository
    {
        private static Database1Entities db = DatabaseSingleton.GetInstance();

        /*---------------------- Start Line Register ---------------------- */
        public int GenerateNewUserId()
        {
            int? lastId = db.Users.Max(x => (int?)x.UserID);
            return (lastId ?? 0) + 1;
        }

        public void AddNewUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        /*---------------------- End Line Register ---------------------- */


        public void AddUser(User newUser)
        {
            if (newUser == null)
            {
                throw new ArgumentNullException(nameof(newUser), "User cannot be null");
            }

            db.Users.Add(newUser);
            db.SaveChanges();
        }
        public bool Verification(string username, string password)
        {
            return db.Users.Any(u => u.Username == username && u.UserPassword == password);
        }

        public User GetUserByUsername(string username)
        {
            return (from u
                    in db.Users
                    where u.Username.Equals(username)
                    select u).FirstOrDefault();
        }

        public User GetUserByID(int id)
        {
            return (from u in db.Users where u.UserID == id select u).FirstOrDefault();
        }

        public List<User> GetAllUser()
        {
            return (from u in db.Users select u).ToList();
        }
    }
}