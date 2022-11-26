using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoGramApi.Models;

namespace StoGramApi.Data
{
    public interface IUserRepo
    {
        bool CheckIfUserExist(string userName);
        UserModel CreateUser(string userName, string password);
        UserModel LogInUser(string userName, string password);

    }
}