using BLL.DTO.CustomerRefundDtos;
using BLL.DTO.OrderDtos;
using BLL.DTO.Seller;
using BLL.Managers.Abstract;
using BLL.Managers.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ANK19_ETicaret.Areas.Seller.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Area("Seller")]
	[Authorize(Roles = "Seller")]
	public class SellerOrderController : ControllerBase
    {
        private readonly IOrderManager _orderManager;
		private readonly ISellerManager _sellerManager;
		private readonly IRefundManager _refundManager;

		public SellerOrderController(IOrderManager orderManager,ISellerManager sellerManager,IRefundManager refundManager)
        {
            _orderManager = orderManager;
			_sellerManager = sellerManager;
			_refundManager = refundManager;
		}


		[HttpGet]
		public ActionResult<int> GetSellerIdByUserId([FromQuery] string sellerUserId)
		{
			
                var sellerId = _sellerManager.GetIdByUserId(sellerUserId);
                return Ok(sellerId);		
		}

		[HttpGet]
        public ActionResult<List<OrderSellerDto>> GetOrdersBySellerId([FromQuery] int sellerId)
        {
            try
            {
                var orderDtoList = _orderManager.OrderSellerDtos(sellerId);
                if (orderDtoList == null || !orderDtoList.Any())
                {
                    return Ok(orderDtoList);
                }
                return Ok(orderDtoList);
            }
            catch (Exception ex)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, "Hata Oluştu.");
            }
        }

       [HttpGet]
        public ActionResult<List<OrderSellerDto>> GetOrderBySellerId([FromQuery]  int sellerId, [FromQuery] int orderId)
        {
            try
            {
                var orderDto = _orderManager.OrderSellerDto(sellerId, orderId);
                if (orderDto == null)
                {
                    return NotFound($"No orders found for SellerId {sellerId}");
                }
                return Ok(orderDto);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Hata Oluştu.");
            }
        }

        [HttpPost]
        public ActionResult UpdateOrderStatusForSeller([FromBody] UpdateOrderStatusManagerDto dto)
        {
            _orderManager.UpdateOrderStatus(dto.Id, dto.Status);

            return Ok();

        }

		[HttpGet]
		public ActionResult<List<GetRefundChangesDto>> GetRefundsChangesFoSeller([FromQuery] int sellerId)
		{
			try
			{
                var refundchangesDtos = _refundManager.GetSellerRefundsChanges(sellerId);
				if (refundchangesDtos == null)
				{
					return NotFound($"No refunds found for SellerId {sellerId}");
				}
				return Ok(refundchangesDtos);
			}
			catch (Exception ex)
			{

				return StatusCode(StatusCodes.Status500InternalServerError, "Hata Oluştu.");
			}
		}

        [HttpDelete]
        public ActionResult DeleteRequest([FromQuery] int requestId)
        {
            _refundManager.DeleteRequest(requestId);

            return NoContent();

        }

        [HttpPost]
        public ActionResult ApproveRequest([FromBody] ApproveRefundChangeForSellerDto approveRefunChangeForSellerDto)
        {
            try
            {
                _refundManager.ApproveRequest(approveRefunChangeForSellerDto);
                    
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Hata Oluştu.");
            }
          

        }



    }
}
