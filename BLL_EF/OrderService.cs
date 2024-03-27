using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_EF
{
    public class OrderService : IOrderService
    {
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;
        private List<OrderDTO> _orders = new List<OrderDTO>();


        public OrderService(IBasketService basketService, IProductService productService)
        {
            _basketService = basketService;
            _productService = productService;
        }
        public async Task CreateOrder(int userId)
        {
            // Opróżnienie koszyka po utworzeniu zamówienia
            await _basketService.RemoveAllProducts(userId);

            // Tworzenie zamówienia
            var order = new OrderDTO
            {
                Id = _orders.Count + 1, // Prosta logika nadania ID
                UserID = userId,
                Date = DateTime.Now,
                OrderPositions = (IEnumerable<OrderPositionDTO>)(await _basketService.GetBasketContents(userId))
                                    .Select(async bp =>
                                    {
                                        var product = (await _productService.GetProductsAsync(new ProductFilterCriteria { IsActive = true }))
                                                        .FirstOrDefault(p => p.Id == bp.ProductID);
                                        if (product != null)
                                        {
                                            return new OrderPositionDTO
                                            {
                                                Id = bp.Id, // Id pozycji w zamówieniu będzie odpowiadać Id w pozycji koszyka
                                                Amount = bp.Amount,
                                                Price = product.Price
                                            };
                                        }
                                        else
                                        {
                                            throw new InvalidOperationException("Product not found or is inactive.");
                                        }
                                    })
            };

            _orders.Add(order);
        }


        public Task<IEnumerable<OrderDTO>> GetAllOrders()
        {
            return Task.FromResult(_orders.AsEnumerable());
        }

        public Task<IEnumerable<OrderPositionDTO>> GetOrderPositions(int orderId)
        {
            var order = _orders.FirstOrDefault(o => o.Id == orderId);
            if (order != null)
            {
                return Task.FromResult(order.OrderPositions.AsEnumerable());
            }
            else
            {
                throw new InvalidOperationException("Order not found.");
            }
        }

        public Task<IEnumerable<OrderDTO>> GetUserOrders(int userId)
        {
            return Task.FromResult(_orders.Where(o => o.UserID == userId).AsEnumerable());
        }
    }
}
