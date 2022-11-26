using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoGramApi.Contexts;
using StoGramApi.Models;

namespace StoGramApi.Data
{
    public class UserRepo : IUserRepo
    {
        private UserDbContext userContext;

        public UserRepo(UserDbContext context)
        {
            userContext = context;
        }

        public UserModel CreateUser(string userName, string password)
        {
            if (CheckIfUserExist(userName))
            {
                return null;
            }

            UserModel newUser = new UserModel()
            {
                Login = userName,
                Password = password
            };

            userContext.Users.Add(newUser);
            userContext.SaveChanges();
            return newUser;

        }

        public UserModel LogInUser(string userName, string password)
        {
            UserModel loginUser = userContext.Users.FirstOrDefault(user => user.Login == userName);
            if (loginUser != null && loginUser.Password == password)
            {
                return loginUser;
            }
            return null;
        }

        public bool CheckIfUserExist(string userName)
        {
            var blogs = from user in userContext.Users
                where user.Login == userName
                select user;

            if (blogs.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}