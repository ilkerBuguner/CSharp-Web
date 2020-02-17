using Andreys.Data;
using Andreys.Models;
using Andreys.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Andreys.Services
{
    public class UsersService : IUsersService
    {
        private readonly AndreysDbContext db;

        public UsersService(AndreysDbContext db)
        {
            this.db = db;
        }

        public void Create(string username, string password, string email)
        {
            var user = new User()
            {
                Username = username,
                Password = HashPassword(password),
                Email = email
            };

            db.Users.Add(user);
            db.SaveChanges();
        }


        public string GetUserId(string username, string password)
        {
            var hashedPassword = HashPassword(password);
            var userId = this.db.Users.Where(u => u.Username == username && u.Password == hashedPassword)
                .Select(u => u.Id)
                .FirstOrDefault();

            return userId;
        }

        public string GetUsernameById(string id)
        {
            return this.db.Users.Where(u => u.Id == id)
                .Select(u => u.Username)
                .FirstOrDefault();
        }

        private string HashPassword(string input)
        {
            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(input));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }

            return hash.ToString();
        }
    }
}
