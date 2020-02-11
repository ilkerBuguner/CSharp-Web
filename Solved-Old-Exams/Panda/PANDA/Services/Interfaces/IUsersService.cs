using PANDA.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PANDA.Services.Interfaces
{
    public interface IUsersService
    {
        void CreateUser(string username, string email, string password);

        string GetUserId(string username, string password);

        IEnumerable<string> GetUsernames();

        User GetUserByUsername(string username);
    }
}
