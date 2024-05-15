using BLL.DTO.BasketPosition;
using BLL.DTO.product;
using BLL.DTO.User;
using BLL.Interface;
using WebApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BLL_EF
{
    public class BasketService : RemoveFromBasket, AddToBasket, ChangeAmountInBasket, GetBasketPositions
    {
        private ShopContext context = new ShopContext();
        public bool AddToBasket(ProductRequestDTO id, UserRequestDTO user)
        {
            var product = context.Products.First(x => x.Id == id.ProductID);
            if (!product.IsActive) return false;
            var pos = new BasketPosition { Amount = 1, Product = context.Products.First(x => x.Id == id.ProductID), User = context.Users.First(x => x.Password == user.Password && x.Login == user.login) };
            context.BasketPositions.Add(pos);
            context.SaveChanges();
            return true;

        }

        public bool ChangeAmount(ProductRequestDTO id, UserRequestDTO user, int amount)
        {
            if (amount <= 0) return false;
            var users = context.Users.First(x => x.Password == user.Password && x.Login == user.login);
            var pos = context.BasketPositions.First(x => x.ProductID == id.ProductID && x.UserID == users.Id);
            pos.Amount = amount;
            context.SaveChanges();
            return true;
        }

        public IEnumerable<BasketPositionResponseDTO> get(UserRequestDTO user)
        {
            var us = context.Users.First(x => x.Password == user.Password && x.Login == user.login);
            var pos = context.BasketPositions.Where(x => x.User == us);

            var list = pos.Select(pos => new BasketPositionResponseDTO { Amount = pos.Amount, Product = new ProductResponseDTO { ID = pos.ProductID, Image = pos.Product.Image, IsActive = pos.Product.IsActive, Name = pos.Product.Name, Price = pos.Product.Price } }).ToList();
            return list;
        }

        public bool RemoveFromBasket(ProductRequestDTO product, UserRequestDTO user)
        {
            var users = context.Users.First(x => x.Password == user.Password && x.Login == user.login);
            var pos = context.BasketPositions.First(x => x.ProductID == product.ProductID && x.UserID == users.Id);
            context.BasketPositions.Remove(pos);
            context.SaveChanges();
            return true;
        }
    }
}
