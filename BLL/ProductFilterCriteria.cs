using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProductFilterCriteria
    {
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
    }
}
