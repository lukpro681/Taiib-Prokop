using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.product
{
    public class ProductResponseDTO
    {
        public int? ID { get; set; }

        public string Name { get; init; }
        public decimal Price { get; init; }
        public string Image { get; init; } 
        public bool IsActive { get; set; }

    }
}
