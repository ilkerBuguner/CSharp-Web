using PANDA.Models;
using PANDA.Models.Enums;
using PANDA.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PANDA.Services
{
    public class PackageService : IPackageService
    {
        private readonly ApplicationDbContext db;
        private readonly IReceiptsService receiptsService;

        public PackageService(ApplicationDbContext db, IReceiptsService receiptsService)
        {
            this.db = db;
            this.receiptsService = receiptsService;
        }
        public void CreatePackage(string description, decimal weight, string shippingAddress, string recipientName)
        {
            var userId = this.db.Users.Where(u => u.Username == recipientName).Select(u => u.Id).FirstOrDefault();


            var package = new Package()
            {
                Description = description,
                Weight = weight,
                ShippingAddress = shippingAddress,
                Status = Status.Pending,
                RecipientId = userId
            };

            this.db.Packages.Add(package);
            db.SaveChanges();
        }

        public Package GetById(string id)
        {
            return this.db.Packages.FirstOrDefault(p => p.Id == id);
        }

        public IQueryable<Package> GetAllByStatus(Status packageStatus)
        {
            return this.db.Packages.Where(p => p.Status == packageStatus);
        }

        public void Deliver(string id)
        {
            var package = db.Packages.FirstOrDefault(p => p.Id == id);

            if (package == null)
            {
                return;
            }

            package.Status = Status.Delivered;
            db.SaveChanges();

            this.receiptsService.CreatefromPackage(package.Weight, package.Id, package.RecipientId);
        }
    }
}
