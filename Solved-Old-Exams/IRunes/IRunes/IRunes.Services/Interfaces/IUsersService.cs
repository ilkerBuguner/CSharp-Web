using System;
using System.Collections.Generic;
using System.Text;

namespace IRunes.Services.Interfaces
{
    public interface IUsersService
    {
        public void Create(string username, string password, string email);

        public string GetUsernameById(string id);

        public string GetUserId(string username, string password);
    }
}
