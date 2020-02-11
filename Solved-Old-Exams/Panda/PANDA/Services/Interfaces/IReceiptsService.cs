using PANDA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PANDA.Services.Interfaces
{
    public interface IReceiptsService
    {
        void CreatefromPackage(decimal weight, string packageId, string userId);

        IQueryable<Receipt> GetAllReceipts();
    }
}
