using BLL;
using BLL.DTO.Order;
using BLL.DTO.OrderPosition;
using BLL.DTO.product;
using BLL.DTO.User;
using BLL.Interface;
using Microsoft.EntityFrameworkCore;
using WebApiModels;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_EF
{
    public class OrderService
    {
      private ShopContext _shopContext = new ShopContext();
    }
}
