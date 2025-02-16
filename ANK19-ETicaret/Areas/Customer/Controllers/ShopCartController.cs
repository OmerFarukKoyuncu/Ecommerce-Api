using BLL.DTO.ShopCartDtos;
using BLL.Managers.Abstract;
using BLL.Managers.Concrete;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ANK19_ETicaret.Areas.Customer.Controllers
{
    [Route("api/[area]/[controller]/[action]")]
    [ApiController]
    [Area("Customer")]
    [Authorize]
    public class ShopCartController : ControllerBase
    {
        private readonly IShopCartManager _shopCartManager;
        private readonly UserManager<User> _userManager;

        public ShopCartController(IShopCartManager shopCartManager, UserManager<User> userManager)
        {
            _shopCartManager = shopCartManager;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult> GetShopCart()
        {
            var userId = _userManager.GetUserId(User);

            if(userId == null)
                return Unauthorized();


            var shopCart = _shopCartManager.GetByUserId(userId);

            return Ok(shopCart);
        }



        [HttpPost]
        public IActionResult AddItemToCart([FromBody] ItemRequest request)
        {
            var userId = _userManager.GetUserId(User);

            if (userId == null)
                return Unauthorized();

            var shopCartId = _shopCartManager.GetIdByUserId(userId);


            _shopCartManager.AddItemById(shopCartId, request.Id,request.Quantity);
            return Ok(new { Message = "Item added to cart successfully." });
        }




        [HttpPost]
        public IActionResult RemoveItemFromCart([FromBody] ItemRequest request)
        {
            var userId = _userManager.GetUserId(User);

            if (userId == null)
                return Unauthorized();


            var shopCartId = _shopCartManager.GetIdByUserId(userId);


            _shopCartManager.RemoveItemById(shopCartId, request.Id);
            return Ok(new { Message = "Item removed from cart successfully." });
        }


        [HttpPost]
        public IActionResult IncrementItem([FromBody] ItemRequest request)
        {
            var userId = _userManager.GetUserId(User);

            if (userId == null)
                return Unauthorized();


            var shopCartId = _shopCartManager.GetIdByUserId(userId);


            _shopCartManager.IncrementItemById(shopCartId, request.Id);
            return Ok(new { Message = "Item incremented successfully." });
        }

        [HttpPost]
        public IActionResult DecrementItem([FromBody] ItemRequest request)
        {
            var userId = _userManager.GetUserId(User);

            if (userId == null)
                return Unauthorized();


            var shopCartId = _shopCartManager.GetIdByUserId(userId);


            _shopCartManager.DecrementItemById(shopCartId, request.Id);
            return Ok(new { Message = "Item decremented successfully." });
        }



        [HttpPost]
        public IActionResult EmptyCart()
        {
            var userId = _userManager.GetUserId(User);

            if (userId == null)
                return Unauthorized();


            var shopCartId = _shopCartManager.GetIdByUserId(userId);


            _shopCartManager.EmptyById(shopCartId);
            return Ok(new { Message = "Shopcart emptied." });
        }
    }
}
