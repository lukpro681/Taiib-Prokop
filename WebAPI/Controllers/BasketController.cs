using BLL;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpPost("{userId}/add/{productId}")]
        public async Task<IActionResult> AddProductToBasket(int userId, int productId, int amount)
        {
            try
            {
                await _basketService.AddProduct(userId, productId, amount);
                return Ok("Product added to basket successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error adding product to basket: {ex.Message}");
            }
        }

        [HttpPut("{userId}/edit/{productId}")]
        public async Task<IActionResult> EditProductAmountInBasket(int userId, int productId, int amount)
        {
            try
            {
                await _basketService.EditProductAmount(userId, productId, amount);
                return Ok("Product amount in basket updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error editing product amount in basket: {ex.Message}");
            }
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetBasketContents(int userId)
        {
            try
            {
                var basketContents = await _basketService.GetBasketContents(userId);
                return Ok(basketContents);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error retrieving basket contents: {ex.Message}");
            }
        }

        [HttpDelete("{userId}/remove/{productId}")]
        public async Task<IActionResult> RemoveProductFromBasket(int userId, int productId)
        {
            try
            {
                await _basketService.RemoveProduct(productId, userId);
                return Ok("Product removed from basket successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error removing product from basket: {ex.Message}");
            }
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
