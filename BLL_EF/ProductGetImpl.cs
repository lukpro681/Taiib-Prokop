using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.DTO.product;
using BLL.Interface;
using WebApiModels;
using DataAccessLayer;

namespace BLL_EF
{

    public class ProductGetImpl : GetProductsASCDSC, GetProductsIsActive, GetProductsName, GetProductsStronnicowo
    {
        public ShopContext context = new ShopContext();
        public IEnumerable<ProductResponseDTO> get(bool ascending)
        {
            var tmp = context.Products;
            if (!ascending)
                tmp.OrderByDescending(x => x.Name);
            else tmp.OrderBy(x => x.Name);
            List<ProductResponseDTO> list = tmp.Select(p => new ProductResponseDTO { ID = p.Id, Name = p.Name, Price = p.Price, Image = p.Image, IsActive = p.IsActive }).ToList();
            return list;

        }

        public IEnumerable<ProductResponseDTO> getPoNazwie(string name)
        {
            var tmp = context.Products.Where(x => x.Name == name);
            List<ProductResponseDTO> list = tmp.Select(p => new ProductResponseDTO { ID = p.Id, Name = p.Name, Price = p.Price, Image = p.Image, IsActive = p.IsActive }).ToList();
            return list;
        }

        public IEnumerable<ProductResponseDTO> getStronnicowo(int strona = 0)
        {
            var tmp = context.Products.OrderBy(x => x.Name).Skip(20 * strona).Take(20);
            List<ProductResponseDTO> list = tmp.Select(p => new ProductResponseDTO { ID = p.Id, Name = p.Name, Price = p.Price, Image = p.Image, IsActive = p.IsActive }).ToList();
            return list;
        }

        public IEnumerable<ProductResponseDTO> getactive(bool IsActive = true)
        {
            var tmp = context.Products.Where((x) => x.IsActive == IsActive).OrderBy(x => x.Name);
            List<ProductResponseDTO> list = tmp.Select(p => new ProductResponseDTO { ID = p.Id, Name = p.Name, Price = p.Price, Image = p.Image, IsActive = p.IsActive }).ToList();
            return list;
        }
    }
}
