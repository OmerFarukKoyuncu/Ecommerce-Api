using System.IdentityModel.Tokens.Jwt;
using AutoMapper;
using BLL.DTO.OrderDtos;
using BLL.DTO.CustomerRefundDtos;
using BLL.Managers.Abstract;
using DAL.Entities;
using DAL.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ANK19_ETicaret.Areas.Customer.Controllers
{
    [Route("api/[area]/[controller]/[action]")]
    [ApiController]
    [Area("Customer")]
    [Authorize]
    public class CustomerOrderController : ControllerBase
    {
        private readonly IShopCartManager _shopCartManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IOrderManager _orderManager;
        private readonly IOrderProductManager _orderProductManager;
        private readonly IProductManager _productManager;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public CustomerOrderController(IShopCartManager shopCartManager,IOrderProductManager orderProductManager,IProductManager productManager, IHttpContextAccessor httpContextAccessor, IOrderManager orderManager, IMapper mapper, UserManager<User> userManager)
        {
            _shopCartManager = shopCartManager;
            _httpContextAccessor = httpContextAccessor;
            _orderManager = orderManager;
           _orderProductManager = orderProductManager;
            _productManager = productManager;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult CheckBasket([FromQuery] string userId)
        {
            try
            {
                var shopcart = _shopCartManager.GetByUserId(userId); //Müşterinin sepetini bulan metot

                if (shopcart == null)
                    return NotFound("Sepet bulunamadı.");

                var errorList = _shopCartManager.CheckStock(shopcart); //Stok kontrolü yapaln metot

                if (!errorList.IsNullOrEmpty())
                {
                    return BadRequest(new { Errors = errorList });
                }

                // Ürünlerde stok sıkıntısı yoksa sipariş oluşturulacak

                var orderId = _orderManager.AddOrder(shopcart); // Order tablosuna kayıt atan metot
                _orderProductManager.AddOrderProduct(orderId, shopcart); // OrderProduct tablosuna kayıt atan metot
                _productManager.UpdateStockAfterOrder(shopcart); // Stoktan düşen metot
                _shopCartManager.EmptyById(shopcart.Id); // Sepeti temizleyen metot

                return Ok(new { Message = "Siparişiniz oluşturulmuştur.", OrderId = orderId });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "Bir hata oluştu", Details = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            try
            {
                var userId = _userManager.GetUserId(User);  
                if (userId == null)
                {
                    return Unauthorized("Kullanıcı kimliği bulunamadı.");
                }
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    return NotFound("Kullanıcı bulunamadı");
                }
                var orders = _orderManager.GetCustomerOrders(userId);
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Bir hata oluştu: " + ex.Message);
            }
        }

    }

}

