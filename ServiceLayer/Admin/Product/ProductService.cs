using DataLayer.EF;
using Microsoft.EntityFrameworkCore;
using ModelAndRequest.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceLayer.Admin.Product
{
    public class ProductService : IProductService
    {
        private readonly EShopDbContext eShopDb;
        public ProductService(EShopDbContext eShopDb)
        {
            this.eShopDb = eShopDb;
        }
        public async Task<List<ProductViewModel>> GetAllProduct()
        {
            var data = from p in eShopDb.Products
                       join c in eShopDb.Categories on p.CategoryId equals c.Id
                       select new { product = p, category = c.Name};

            var result = await data?.Select(x => new ProductViewModel()
            {
                Id = x.product.Id,
                Image = x.product.ProductImage,
                Name = x.category,
                Category = x.category,
                Available = x.product.Available,
            }).ToListAsync();

            return result;
        }

        public ProductDetailViewModel GetProductById(int id)
        {
            var data = (from p in eShopDb.Products
                       join c in eShopDb.Categories on p.CategoryId equals c.Id
                       where p.Id == id
                       select new { product = p, category = c.Name }).FirstOrDefault();

            if (data == null)
                return null;

            var result = new ProductDetailViewModel()
            {
                Id = data.product.Id,
                Name = data.product.Name,
                CategoryId = data.product.CategoryId,
                Category = data.category,
                Description = data.product.Description,
                Image = data.product.ProductImage,
                Available = data.product.Available
            };

            return result;
        }
    }
}
