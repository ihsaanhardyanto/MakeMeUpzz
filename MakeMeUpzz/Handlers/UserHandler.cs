using MakeMeUpzz.Models;
using MakeMeUpzz.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MakeMeUpzz.Handlers
{
    public class UserHandler
    {
        private readonly UserRepository iniUserRepository;

        public UserHandler()
        {
            iniUserRepository = new UserRepository();
        }

        public int CreateUserId()
        {
            return iniUserRepository.GenerateNewUserId();
        }

        public void AddUser(User user)
        {
            iniUserRepository.AddNewUser(user);
        }

        public bool ValidateUser(string username, string password)
        {
            return iniUserRepository.Verification(username, password);
        }
    }
}
