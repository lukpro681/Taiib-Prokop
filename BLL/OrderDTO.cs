using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class OrderDTO
    {
        public int Id { get; init; }
        public int UserID { get; init; }
        public DateTime Date { get; init; }
        public IEnumerable<OrderPositionDTO> OrderPositions { get; init; }
    }
}
