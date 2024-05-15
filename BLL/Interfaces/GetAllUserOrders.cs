using BLL.DTO.Order;
using BLL.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface GetAllUserOrders
    {
        public IEnumerable<OrderResponseDTO> get(UserRequestDTO user);
    }
}
