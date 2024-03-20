using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IOrderService
    {
        Task CreateOrder(int userId);
        Task<IEnumerable<OrderDTO>> GetAllOrders();
        Task<IEnumerable<OrderDTO>> GetUserOrders(int userId);
        Task<IEnumerable<OrderPositionDTO>> GetOrderPositions(int orderId);
    }
}
