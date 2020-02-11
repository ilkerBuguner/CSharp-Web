using SULS.Data;
using SULS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SULS.Services
{
    public class UserService : IUserService
    {
        private readonly SULSContext db;

        public UserService(SULSContext db)
        {
            this.db = db;
        }

        public async Task CreateUser(string username, string email, string password)
        {
            var user = new User()
            {
                Username = username,
                Email = email,
                Password = HashPassword(password)
            };

            db.Users.Add(user);
            await db.SaveChangesAsync();
        }

        public User GetUserOrNull(string username, string password)
        {
            var user = db.Users.FirstOrDefault(u => u.Username == username && u.Password == HashPassword(password));

            return user;
        }

        public User GetUserByIdOrNull(string id)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == id);

            return user;
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                return Encoding.UTF8.GetString(sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }
    }
}
