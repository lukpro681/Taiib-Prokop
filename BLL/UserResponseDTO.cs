using BLL.DTO.BasketPosition;
using BLL.DTO.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.User
{
    public class UserResponseDTO
    {
        public IEnumerable<BasketPositionResponseDTO> BasketPositions { get; set; }
        public IEnumerable<OrderResponseDTO> Orders { get; init; }
        public bool IsActive { get; set; }
    }
}
