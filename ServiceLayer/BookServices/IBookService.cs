using ModelAndRequest.API;
using ModelAndRequest.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.BookServices
{
    public interface IBookService
    {
        Task<ApiResult<object>> GetAll();
        Task<ApiResult<object>> GetBook(int page = 1, int size = 10, string orderBy = "Price", bool dsc = false, int? categoryId = null, string search = null, bool? isSuspend = null);
        Task<ApiResult<object>> GetBookById(int id);
        // return id product
        Task<ApiResult<bool>> AddBook(BookRequest bookRequest);
        Task<ApiResult<bool>> EditBook(int id, BookRequest bookRequest);
        Task<ApiResult<bool>> DeleteBook(int id);
    }
}
