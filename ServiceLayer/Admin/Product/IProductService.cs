using ModelAndRequest.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Admin.Product
{
    public interface IProductService
    {
        Task<List<ProductViewModel>> GetAllProduct();
        ProductDetailViewModel GetProductById(int id);
    }
}
