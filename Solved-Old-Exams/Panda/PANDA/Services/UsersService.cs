using PANDA.Models;
using PANDA.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace PANDA.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;

        public UsersService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateUser(string username, string email, string password)
        {
            var user = new User()
            {
                Username = username,
                Email = email,
                Password = HashPassword(password)
            };

            db.Users.Add(user);
            db.SaveChanges();
        }

        public User GetUserByUsername(string username)
        {
            return this.db.Users.FirstOrDefault(u => u.Username == username);
        }

        public string GetUserId(string username, string password)
        {
            var user = db.Users.Where(x => x.Username == username && x.Password == HashPassword(password))
                .Select(x => x.Id)
                .FirstOrDefault();
            return user;
        }

        public IEnumerable<string> GetUsernames()
        {
            return this.db.Users.Select(u => u.Username).ToList();
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
