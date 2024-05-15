using BLL;
using BLL.DTO.BasketPosition;
using BLL.DTO.product;
using BLL.DTO.User;
using Microsoft.AspNetCore.Mvc;
using BLL_EF;

namespace WebAPI.Controllers
{

    [ApiController]
    [Route("/api/[controller]")]
    public class BasketController : ControllerBase
    {
        readonly BasketService _basketService;
        public BasketController(BasketService interakcjaZKoszykiem)
        {
            this._basketService = interakcjaZKoszykiem;
        }
        [HttpPost]
        [Route("/add")]
        public bool Post([FromQuery] ProductRequestDTO id, [FromQuery] UserRequestDTO user)
        {
            return _basketService.AddToBasket(id, user);
        }
        [HttpPut]
        [Route("/change/{amount}")]
        public bool Change([FromQuery] ProductRequestDTO id, [FromQuery] UserRequestDTO user, [FromRoute] int amount)
        {
            return _basketService.ChangeAmount(id, user, amount);
        }
        [HttpGet]

        public IEnumerable<BasketPositionResponseDTO> getuser(UserRequestDTO user)
        {
            return _basketService.get(user);
        }
        [HttpDelete]
        public bool remove([FromQuery] UserRequestDTO user, [FromQuery] ProductRequestDTO product)
        {
            return _basketService.RemoveFromBasket(product, user);
        }
    }
}
