using BLL.DTO;
using BLL.DTO.CustomerRefundDtos;
using BLL.DTO.OrderDtos;
using BLL.Managers.Abstract;
using BLL.Managers.Concrete;
using DAL.Entities;
using DAL.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ANK19_ETicaret.Areas.Customer.Controllers
{
    [Route("api/[area]/[controller]/[action]")]
    [ApiController]
    [Area("Customer")]
    [Authorize]
    public class CustomerRefundController : ControllerBase
    {
        private readonly IRefundManager _refundManager;
        private readonly IOrderManager _orderManager;

        public CustomerRefundController(IRefundManager refundManager,IOrderManager orderManager)
        {
          _refundManager = refundManager;
            _orderManager = orderManager;
        }

		[HttpPost]	
		public IActionResult AddRefundChange([FromBody] AddRefundChangeDto request)
		{
			if (!Enum.IsDefined(typeof(RequestType), request.Request))
			{
				return BadRequest("Invalid request type.");
			}

			
			var result = _refundManager.AddRefundChange(request.UserId, request.ProductId, request.Request);

			return Ok(new { Message = result.ToString() });
		}


		[HttpGet]
        public ActionResult<List<GetRefundChangesDto>> GetUserRefundsChanges([FromQuery] string userId)
        {
           
            try
            {
                var userRefundsChanges = _refundManager.GetUserRefundsChanges(userId);
                if (userRefundsChanges == null || !userRefundsChanges.Any())
                {
                    return NotFound($"No orders found for UserId {userId}");
                }
                return Ok(userRefundsChanges);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Hata Oluştu.");
            }
           
        }

        [HttpGet]
        public ActionResult<List<OrderUserDto>> GetOrdersByUserId([FromQuery] string userId)
        {
            try
            {
                var orderDtoList = _orderManager.OrderUserDtos(userId);
                if (orderDtoList == null || !orderDtoList.Any())
                {
                    return NotFound($"No orders found for UserId {userId}");
                }
                return Ok(orderDtoList);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


    }
}
