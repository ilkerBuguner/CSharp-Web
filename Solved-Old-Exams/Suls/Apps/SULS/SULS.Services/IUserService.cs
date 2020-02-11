using SULS.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SULS.Services
{
    public interface IUserService
    {
        Task CreateUser(string username, string email, string password);

        User GetUserOrNull(string username, string password);

        User GetUserByIdOrNull(string id);
    }
}
