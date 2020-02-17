using Andreys.Services.Interfaces;
using Andreys.ViewModels.Products;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andreys.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public HttpResponse Add()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(CreateProductInputModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (input.Name.Length < 4 || input.Name.Length > 20)
            {
                return this.Redirect("/Products/Add");
            }

            if (input.Description.Length > 10)
            {
                return this.Redirect("/Products/Add");
            }

            if (String.IsNullOrWhiteSpace(input.Price.ToString()))
            {
                return this.Redirect("/Products/Add");
            }

            if (String.IsNullOrWhiteSpace(input.Category))
            {
                return this.Redirect("/Products/Add");
            }

            if (String.IsNullOrWhiteSpace(input.Gender))
            {
                return this.Redirect("/Products/Add");
            }

            this.productsService.Create(input.Name, input.Description, input.ImageUrl, input.Category, input.Gender, input.Price);

            return this.Redirect("/Home/Index");
        }

        public HttpResponse Details(int id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var product = this.productsService.GetById(id);

            var viewModel = new ProductDetailsViewModel()
            {
                Id = id,
                Name = product.Name,
                Description = product.Description,
                Category = product.Category.ToString(),
                Gender = product.Gender.ToString(),
                ImageUrl = product.ImageUrl,
                Price = product.Price
            };

            return this.View(viewModel);
        }

        public HttpResponse Delete(int id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.productsService.DeleteById(id);

            return this.Redirect("/Home/Index");
        }
    }
}
