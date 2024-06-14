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

        /*----------------------   Register   ---------------------- */
        /*---------------------- Start Line  ---------------------- */
        public int GenerateNewUserId()
        {
            int? lastId = db.Users.Max(x => (int?)x.UserID);
            return (lastId ?? 0) + 1;
        }

        public void AddNewUser(User newUser)
        {
            db.Users.Add(newUser);
            db.SaveChanges();
        }
        /*---------------------- End Line  ---------------------- */
        /*----------------------   Register   ---------------------- */


        /*----------------------   Login   ---------------------- */
        /*---------------------- Start Line  ---------------------- */
        public User GetUserByUsername(string username)
        {
            return (from u
                    in db.Users
                    where u.Username.Equals(username)
                    select u).FirstOrDefault();
        }

        public bool Verification(string username, string password)
        {
            var users = db.Users.Any(u => u.Username == username && u.UserPassword == password);
            return users;
        }
        /*---------------------- End Line  ---------------------- */
        /*----------------------   Login   ---------------------- */


        /*----------------------   HomePage   ---------------------- */
        /*---------------------- Start Line  ---------------------- */

        public User GetUserByID(int id)
        {
            return (from u in db.Users where u.UserID == id select u).FirstOrDefault();
        }

        public List<User> GetAllUser()
        {
            return (from u in db.Users select u).ToList();
        }

        /*----------------------   HomePage   ---------------------- */
        /*---------------------- End Line  ---------------------- */

        /*-------------------   Profile Page   ---------------------- */
        /*---------------------- Start Line  ---------------------- */
        public void ModifyUserData(int id, string name, string email, DateTime DOB, string gender, string role, string password)
        {
            User user = db.Users.Find(id);
            user.UserID = id;
            user.Username = name;
            user.UserEmail = email;
            user.UserDOB = DOB;
            user.UserGender = gender;
            user.UserRole = role;
            user.UserPassword = password;

            db.SaveChanges();
        }

        public void ModifyUserPass(int id, string new_password)
        {
            User user = db.Users.Find(id);
            if (user != null)
            {
                user.UserPassword = new_password;
                db.SaveChanges();
            }
        }

        /*-------------------   Profile Page  ---------------------- */
        /*---------------------- End Line  ---------------------- */
    }
}