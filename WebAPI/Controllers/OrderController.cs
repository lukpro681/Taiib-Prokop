using BLL;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("{userId}/create")]
        public async Task<IActionResult> CreateOrder(int userId)
        {
            try
            {
                await _orderService.CreateOrder(userId);
                return Ok("Order created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error creating order: {ex.Message}");
            }
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrder(int orderId)
        {
            try
            {
                var order = await _orderService.GetOrderPositions(orderId);
                if (order == null)
                {
                    return NotFound("Order not found.");
                }
                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error retrieving order: {ex.Message}");
            }
        }

        [HttpGet("{userId}/all")]
        public async Task<IActionResult> GetUserOrders(int userId)
        {
            try
            {
                var orders = await _orderService.GetUserOrders(userId);
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error retrieving user orders: {ex.Message}");
            }
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllOrders()
        {
            try
            {
                var orders = await _orderService.GetAllOrders();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error retrieving all orders: {ex.Message}");
            }
        }

        [HttpGet("{orderId}/positions")]
        public async Task<IActionResult> GetOrderPositions(int orderId)
        {
            try
            {
                var orderPositions = await _orderService.GetOrderPositions(orderId);
                return Ok(orderPositions);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error retrieving order positions: {ex.Message}");
            }
        }
        public IActionResult Index()
        {
            return View();
        }
    }

}
