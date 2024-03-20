using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProductsAsync(ProductFilterCriteria criteria);
        Task AddProduct(ProductDTO product);
        Task DeleteProduct(int productId, ProductDTO updatedProduct);
        Task EditProduct(ProductDTO product);
        Task ActivateProduct(ProductDTO product);
    }
}
