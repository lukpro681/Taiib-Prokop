using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProductsAsync(ProductFilterCriteria criteria);

        //Task<IEnumerable<ProductDTO>> GetProducts();
        Task AddProduct(ProductDTO product);
        Task DeleteProduct(int productId);
        Task EditProduct(ProductDTO product);
        Task ActivateProduct(ProductDTO product);
    }
}
