using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MakeMeUpzz.Models;

namespace MakeMeUpzz.Factory
{
    public class UserRegisterFactory
    {
        public static User CreateUser(int id, string username, string email, DateTime DOB, string gender, string role, string password)
        {
            User newUser = new User();
            newUser.UserID = id;
            newUser.Username = username;
            newUser.UserEmail = email;
            newUser.UserDOB = DOB;
            newUser.UserGender = gender;
            newUser.UserRole = role;
            newUser.UserPassword = password;

            return newUser;
        }
    }
}