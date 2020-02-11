using PANDA.Services.Interfaces;
using PANDA.ViewModels.Receipts;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PANDA.Controllers
{
    public class ReceiptsController : Controller
    {
        private readonly IReceiptsService receiptsService;

        public ReceiptsController(IReceiptsService receiptsService)
        {
            this.receiptsService = receiptsService;
        }


        public HttpResponse Index()
        {
            var receipts = this.receiptsService.GetAllReceipts().Select(r => new ReceiptViewModel
            {
                Id = r.Id,
                Fee = r.Fee,
                IssuedOn = r.IssuedOn,
                RecipientName = r.Recipient.Username
            }).ToList();

            return this.View(receipts);
        }
    }
}
