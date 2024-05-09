using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BLL;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService) 
        { 
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductDTO product)
        {
            try
            {
                await _productService.AddProduct(product);
                return Ok("Product added successfully."); //OK oznacza wygenerowanie kodu 200 oraz pokazaniu wyniku operacji
            }
            catch (Exception ex)
            {
                return BadRequest($"Error adding product: {ex.Message}"); //błąd 400 BadRequest
            }
        }

        [HttpPut("{productId}")]
        public async Task<IActionResult> EditProduct(int productId, ProductDTO product)
        {
            try
            {
                // Sprawdzenie czy podane ID jest identyczne jak w DTO
                if (productId != product.Id)
                {
                    return BadRequest("Product ID mismatch.");
                }

                await _productService.EditProduct(product);
                return Ok("Product updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error updating product: {ex.Message}");
            }
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            try
            {
                await _productService.DeleteProduct(productId);
                return Ok("Product deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error deleting product: {ex.Message}");
            }
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProduct(int productId)
        {
            try
            {
                // Tworzenie obiektu ProductFilterCriteria z podanym productId
                var filterCriteria = new ProductFilterCriteria
                {
                    Name = null, // domyślnie Nie stosujemy filtra na nazwę
                    IsActive = null, // domyślnie Nie stosujemy filtra na aktywność
                    PageNumber = 1, // domyślnie Pobieramy tylko pierwszą stronę wyników
                    PageSize = 1, // domyślnie Pobieramy tylko jeden produkt
                    SortBy = null, // domyślnie niestandardowe sortowanie wyłączone
                    IsSortAscending = true // domyślnie sortowanie rosnąco
                };

                var products = await _productService.GetProductsAsync(filterCriteria);
                var product = products.FirstOrDefault(p => p.Id == productId); // Znajdujemy produkt o podanym Id

                if (product == null)
                {
                    return NotFound("Product not found."); //błąd 404
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error retrieving product: {ex.Message}");
            }
        }

/*        public IActionResult Index()
        {
            return View();
        }*/
    }
}
