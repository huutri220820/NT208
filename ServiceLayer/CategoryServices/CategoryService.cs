using DataLayer.EF;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using ModelAndRequest.API;
using ModelAndRequest.Book;
using ModelAndRequest.Category;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceLayer.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly EShopDbContext eShopDbContext;

        public CategoryService(EShopDbContext eShopDbContext)
        {
            this.eShopDbContext = eShopDbContext;
        }
        public async Task<ApiResult<bool>> AddCategory(CategoryRequest categoryRequest)
        {
            var category = new Category()
            {
                Name = categoryRequest.name,
                KeyWord = categoryRequest.keyword
            };
            eShopDbContext.Categories.Add(category);

            var result = await eShopDbContext.SaveChangesAsync();
            if (result > 0)
                return new ApiResult<bool>(success: true, messge: "thanh cong", payload: true);

            return new ApiResult<bool>(success: true, messge: "Them that bai", payload: false);
        }

        public async Task<ApiResult<bool>> EditCategory(int id ,CategoryRequest categoryRequest)
        {
            var category = await eShopDbContext.Categories.FindAsync(id);
            if(category == null)
                return new ApiResult<bool>(success: false, messge: "Khong tim that", payload: false);

            category.Name = categoryRequest.name;
            category.KeyWord = categoryRequest.keyword ?? category.KeyWord;

            var result =  await eShopDbContext.SaveChangesAsync();
            if (result > 0)
                return new ApiResult<bool>(success: true, messge: "thanh cong", payload: true);

            return new ApiResult<bool>(success: true, messge: "Khong cap nhat", payload: false);


        }

        public async Task<ApiResult<object>> GetAllBook(int id)
        {
            var result = eShopDbContext.Categories.Find(id)?.Books.Select(x => new BookViewModel()
            {
                id = x.Id,
                name = x.Name,
                available = x.Available,
                category = x.Category.Name,
                image = x.BookImage,
                price = x.Price,
                sale = x.Sale
            }).ToList();
            if(result == null)
                return new ApiResult<object>(success: false, messge: "Khong tim thay danh muc", payload: null);

            return new ApiResult<object>(success: true, messge: "Thanh cong", payload: new { books = result });
        }

        public async Task<ApiResult<object>> GetAllCategory()
        {
            var result = await eShopDbContext.Categories?.Select(x => new CategoryModel()
            {
                id = x.Id,
                name = x.Name
            }).ToListAsync();
            if (result == null)
                return new ApiResult<object>(success: false, messge: "Khong tim thay danh muc", payload: null);


            return new ApiResult<object>(success: true, messge: "Thanh cong", payload: new { categories = result });
        }
    }
}
