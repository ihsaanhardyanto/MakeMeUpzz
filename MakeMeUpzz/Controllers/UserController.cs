using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Controllers
{
    public class UserController
    {
        public static String CheckUsername(string username)
        {
            String response = "";
            if (string.IsNullOrEmpty(username)) response = "Username cannot be empty";
            else if (username.Length < 5 || username.Length > 15) response = "Username must be between 5 to 15 characters!";
            return response;
        }

        public static String CheckEmail(string email)
        {
            String response = "";

            if (string.IsNullOrEmpty(email))
            {
                response = "Email cannot be empty";
            }
            else if (!email.Contains(".com")) response = "Email must end with .com!";

            return response;
        }

        public static String CheckPassword(string password)
        {
            String response = "";

            if (string.IsNullOrEmpty(password))
            {
                response = "Password cannot be empty";
            }
            return response;
        }

        public static String CheckConfirmPassword(string confirmpassword, string password)
        {
            String response = "";
            if (string.IsNullOrEmpty(confirmpassword))
            {
                response = "Confirmation password cannot be empty!";
            }
            else if (confirmpassword != password)
            {
                response = "Passwords must match!";
            }

            return response;
        }

        public static String CheckGender(bool gender1, bool gender2)
        {
            String response = "";
            if (!gender1 && !gender2)
            {
                response = "Gender must be chosen and cannot be empty";
            }

            return response;
        }

        public static String CheckDOB(string dob)
        {
            String response = "";
            if (string.IsNullOrEmpty(dob))
            {
                response = "Date of birth cannot be empty";
            }

            return response;
        }
        public static User GetUserByID(int id)
        {
            // Logika untuk mendapatkan pengguna dari database berdasarkan ID
            // Misalnya:
            using (var context = new Database1Entities())
            {
                return context.Users.FirstOrDefault(user => user.UserID == id);
            }
        }
    }
}