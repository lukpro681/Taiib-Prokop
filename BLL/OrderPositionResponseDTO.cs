using BLL.DTO.product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.OrderPosition
{
    public class OrderPositionResponseDTO
    {
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public ProductResponseDTO Product { get; set; }
    }
}
