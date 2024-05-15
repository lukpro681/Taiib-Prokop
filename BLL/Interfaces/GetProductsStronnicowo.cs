using BLL.DTO.product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface GetProductsStronnicowo
    {
        public IEnumerable<ProductResponseDTO> getStronnicowo(int strona=0); 
    }
}
