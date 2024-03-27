using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_EF
{
    public class BasketService : IBasketService
    {
        private List<BasketPositionDTO> _basketContents = new List<BasketPositionDTO>();
        private readonly IProductService _productService;

        public BasketService(IProductService productService)
        {
            _productService = productService;
        }

        public async Task AddProduct(int userId, int productId, int amount)
        {
            // Sprawdzenie czy produkt istnieje
            var product = (await _productService.GetProductsAsync(new ProductFilterCriteria { IsActive = true })).FirstOrDefault(p => p.Id == productId);
            if (product == null)
            {
                throw new InvalidOperationException("Product not found or is inactive.");
            }

            _basketContents.Add(new BasketPositionDTO { UserID = userId, ProductID = productId, Amount = amount });
        }

        public async Task EditProductAmount(int userId, int productId, int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be greater than 0.");
            }

            var basketPosition = _basketContents.FirstOrDefault(b => b.UserID == userId && b.ProductID == productId);
            if (basketPosition != null)
            {
                basketPosition.Amount = amount;
            }
            else
            {
                throw new InvalidOperationException("Basket position not found.");
            }
        }

        public Task<IEnumerable<BasketPositionDTO>> GetBasketContents(int userId)
        {
            return Task.FromResult(_basketContents.Where(b => b.UserID == userId).AsEnumerable());
        }

        public Task RemoveProduct(int productId, int userId)
        {
            _basketContents.RemoveAll(b => b.UserID == userId && b.ProductID == productId);
            return Task.CompletedTask;
        }
        public Task RemoveAllProducts(int userId)
        {
            _basketContents.RemoveAll(b => b.UserID == userId);
            return Task.CompletedTask;
        }
    }
}
