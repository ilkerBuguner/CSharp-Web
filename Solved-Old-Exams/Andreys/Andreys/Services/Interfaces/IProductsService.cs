using Andreys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Andreys.Services.Interfaces
{
    public interface IProductsService
    {
        void Create(string name, string description, string imageUrl, string category, string gender, decimal price);

        IQueryable<Product> GetAll();

        Product GetById(int id);

        void DeleteById(int id);
    }
}
