using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserDTO
    {
        public int ID { get; init; }
        public string Login { get; init; }
        public string Password { get; init; }
        public Type Type { get; init; }
        public bool IsActive { get; init; }
        public IEnumerable<BasketPositionDTO> BasketPositions { get; init; }
        public IEnumerable<OrderDTO> Orders { get; init; }
    }
}
