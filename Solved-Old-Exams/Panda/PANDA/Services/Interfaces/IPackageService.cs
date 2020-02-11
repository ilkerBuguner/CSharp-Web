using PANDA.Models;
using PANDA.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PANDA.Services.Interfaces
{
    public interface IPackageService
    {
        void CreatePackage(string description, decimal weight, string shippingAddress, string recipientName);

        IQueryable<Package> GetAllByStatus(Status packageStatus);

        Package GetById(string id);

        void Deliver(string id);
    }
}
