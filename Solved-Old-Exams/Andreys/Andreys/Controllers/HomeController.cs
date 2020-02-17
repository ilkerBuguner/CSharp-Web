namespace Andreys.App.Controllers
{
    using Andreys.Services.Interfaces;
    using Andreys.ViewModels.Products;
    using SIS.HTTP;
    using SIS.MvcFramework;
    using System.Linq;

    public class HomeController : Controller
    {
        private readonly IProductsService productsService;

        public HomeController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn())
            {
                var products = new ProductsListingViewModel()
                {
                    Products = this.productsService.GetAll().Select(p => new ProductInfoViewModel
                    {
                        Id = p.Id,
                        Name = p.Name,
                        ImageUrl = p.ImageUrl,
                        Price = p.Price
                    })
                };

                return this.View(products, "Home");
            }

            return this.View();
        }

        [HttpGet("/")]
        public HttpResponse IndexSlash()
        {
            return this.Index();
        }
    }
}
