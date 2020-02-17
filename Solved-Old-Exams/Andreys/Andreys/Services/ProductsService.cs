using Andreys.Data;
using Andreys.Models;
using Andreys.Models.Enums;
using Andreys.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Andreys.Services
{
    public class ProductsService : IProductsService
    {
        private readonly AndreysDbContext db;

        public ProductsService(AndreysDbContext db)
        {
            this.db = db;
        }

        public void Create(string name, string description, string imageUrl, string category, string gender, decimal price)
        {
            var product = new Product()
            {
                Name = name,
                Description = description,
                ImageUrl = imageUrl,
                Price = price,
                Category = Enum.Parse<ProductCategory>(category),
                Gender = Enum.Parse<ProductGender>(gender)
            };

            this.db.Products.Add(product);
            this.db.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var product = this.db.Products.Find(id);

            this.db.Products.Remove(product);
            this.db.SaveChanges();
        }

        public IQueryable<Product> GetAll()
        {
            return this.db.Products;
        }

        public Product GetById(int id)
        {
            return this.db.Products.Find(id);
        }
    }
}
