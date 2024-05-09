using System;
using System.Collections.Generic;
using BLL;

namespace BLL_EF
{
    public class ProductService : IProductService
    {
        private List<ProductDTO> _products = new List<ProductDTO>();
        public Task ActivateProduct(ProductDTO product)
        {
            if (product.IsActive)
            {
                throw new InvalidOperationException("Product is already active.");
            }

            product.IsActive = true;
            // aktywacja produktu
            return Task.CompletedTask;
        }

        public Task DeleteProduct(int productId)
        {
            // Jeśli produkt jest powiązany z pozycją nieopłaconego zamówienia lub koszyka, nie możemy go usunąć ani zdezaktywować
            if (_products.Any(p => p.Id == productId))
            {
                throw new InvalidOperationException("Product cannot be deleted because it is associated with an unpaid order or basket.");
            }

            // Jeśli produkt jest powiązany z pozycją zamówienia, dezaktywujemy go
            var product = _products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                product.IsActive = false;
            }

            return Task.CompletedTask;
        }

        public Task EditProduct(ProductDTO product)
        {
            // Jeżeli cena jest mniejsza od 0 wygeneruj błąd 400 BadRequest
            if (product.Price <= 0)
            {
                throw new ArgumentException("Price must be greater than 0 PLN.");
            }

            var existingProduct = _products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.Image = product.Image;
                existingProduct.IsActive = product.IsActive;
            }
            // Jeżeli produkt nie jest znaleziony, wygeneruj błąd 404
            else
            {
                throw new InvalidOperationException("Product not found.");
            }
            // status 200 (OK)
            return Task.CompletedTask;
        }

        public Task<IEnumerable<ProductDTO>> GetProductsAsync(ProductFilterCriteria criteria)
        {
            // pobieranie produktów zgodnie z kryteriami filtrowania
            IEnumerable<ProductDTO> filteredProducts = _products;

            if (!string.IsNullOrEmpty(criteria.Name))
            {
                filteredProducts = filteredProducts.Where(p => p.Name.Contains(criteria.Name, StringComparison.OrdinalIgnoreCase));
            }

            if (criteria.IsActive.HasValue)
            {
                filteredProducts = filteredProducts.Where(p => p.IsActive == criteria.IsActive.Value);
            }

            // Sortowanie
            switch (criteria.SortBy)
            {
                case "Price":
                    filteredProducts = criteria.IsSortAscending ? filteredProducts.OrderBy(p => p.Price) : filteredProducts.OrderByDescending(p => p.Price);
                    break;
                default:
                    filteredProducts = filteredProducts.OrderBy(p => p.Id); // Domyślne sortowanie po Id
                    break;
            }

            // Paginacja
            filteredProducts = filteredProducts.Skip((criteria.PageNumber - 1) * criteria.PageSize).Take(criteria.PageSize);

            return Task.FromResult(filteredProducts);
        }

        Task IProductService.AddProduct(ProductDTO product)
        {
            if (product.Price <= 0)
            {
                throw new ArgumentException("Price must be greater than 0.");
            }

            _products.Add(product);
            return Task.CompletedTask;
        }

    }
}