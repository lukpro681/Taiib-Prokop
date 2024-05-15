using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BLL;
using BLL_EF;
using BLL.DTO.product;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProductController : ControllerBase
    {
        readonly ProductService _productService;
        readonly ProductGetImpl _productsFiltersCriteria;

        public ProductController(ProductService interakcjaZProduktem, ProductGetImpl productFilterCriteria)
        {
            this._productService = interakcjaZProduktem;
            this._productsFiltersCriteria = productFilterCriteria;
        }

        [HttpPost]
        [Route("/{state}")]
        public bool activate([FromQuery] ProductRequestDTO id, bool state)
        {
            return _productService.Activate(id, state);
        }
        [HttpPost]
        [Route("/product/add")]
        public bool add([FromQuery] ProductResponseDTO product)
        {
            return _productService.add(product);
        }
        [HttpPost]
        public bool edit([FromQuery] ProductRequestDTO product, [FromQuery] ProductResponseDTO productResponseDTO)
        {

            return _productService.edit(product, productResponseDTO);
        }
        [HttpDelete]
        public bool remove([FromQuery] ProductRequestDTO id)
        {
            return _productService.remove(id);
        }
        [HttpGet]
        [Route("/asc/{ascending}")]
        public IEnumerable<ProductResponseDTO> get([FromRoute] bool ascending)
        {
            return _productsFiltersCriteria.get(ascending);
        }
        [HttpGet]
        [Route("/name/{name}")]
        public IEnumerable<ProductResponseDTO> gegetPoNazwiet([FromRoute] string name)
        {
            return _productsFiltersCriteria.getPoNazwie(name);
        }
        [HttpGet]
        [Route("/strona/{strona}")]
        public IEnumerable<ProductResponseDTO> getStronnicowo([FromRoute] int strona)
        {
            return _productsFiltersCriteria.getStronnicowo(strona);
        }
        [HttpGet]
        [Route("/state/{state}")]
        public IEnumerable<ProductResponseDTO> getactive([FromRoute] bool state)
        {
            return _productsFiltersCriteria.getactive(state);
        }

    }
}

