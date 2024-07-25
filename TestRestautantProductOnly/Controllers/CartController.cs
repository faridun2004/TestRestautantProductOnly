using Microsoft.AspNetCore.Mvc;
using TestRestautantProductOnly.Model;
using TestRestautantProductOnly.Service;

namespace TestRestautantProductOnly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("{userId}")]
        public ActionResult<Cart> GetCart(int userId)
        {
            if (!_cartService.UserExists(userId))
            {   
                return NotFound("User not found.");
            }
            return Ok(_cartService.GetCart(userId));
        }

        [HttpPost("{userId}")]
        public ActionResult AddToCart(int userId, [FromBody] CartItem item)
        {
            if (!_cartService.UserExists(userId))
            {
                return NotFound("User not found.");
            }
            _cartService.AddToCart(userId, item);
            return Ok();
        }

        [HttpDelete("{userId}/{productId}")]
        public ActionResult RemoveFromCart(int userId, int productId)
        {
            if (!_cartService.UserExists(userId))
            {
                return NotFound("User not found.");
            }
            _cartService.RemoveFromCart(userId, productId);
            return Ok();
        }

        [HttpDelete("{userId}/clear")]
        public ActionResult ClearCart(int userId)
        {
            if (!_cartService.UserExists(userId))
            {
                return NotFound("User not found.");
            }
            _cartService.ClearCart(userId);
            return Ok();
        }

        [HttpPut("{userId}/update-quantity")]
        public IActionResult UpdateQuantity(int userId, [FromBody] UpdateQuantityRequest request)
        {
            if (!_cartService.UserExists(userId))
            {
                return NotFound("User not found.");
            }
            _cartService.UpdateQuantity(userId, request.ProductId, request.NewQuantity);
            return Ok();
        }
    }
}

