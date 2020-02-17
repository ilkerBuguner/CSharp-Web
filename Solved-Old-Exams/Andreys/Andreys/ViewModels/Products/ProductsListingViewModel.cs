using System;
using System.Collections.Generic;
using System.Text;

namespace Andreys.ViewModels.Products
{
    public class ProductsListingViewModel
    {
        public IEnumerable<ProductInfoViewModel> Products { get; set; }
    }
}
