using PANDA.Models;
using PANDA.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PANDA.Services
{
    public class ReceiptsService : IReceiptsService
    {
        private readonly ApplicationDbContext db;

        public ReceiptsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreatefromPackage(decimal weight, string packageId, string userId)
        {
            var recepit = new Receipt()
            {
                PackageId = packageId,
                RecipientId = userId,
                IssuedOn = DateTime.UtcNow,
                Fee = weight * 2.67M
            };

            this.db.Receipts.Add(recepit);
            db.SaveChanges();
        }

        public IQueryable<Receipt> GetAllReceipts()
        {
            return this.db.Receipts;
        }
    }
}
