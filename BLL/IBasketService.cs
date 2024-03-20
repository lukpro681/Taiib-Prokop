using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IBasketService
    {
        Task AddProduct(int userId, int productId, int amount);
        Task RemoveProduct(int productId, int userId);
        Task EditProductAmount(int userId, int productId, int amount);
        Task<IEnumerable<BasketPositionDTO>> GetBasketContents(int userId);

    }
}
