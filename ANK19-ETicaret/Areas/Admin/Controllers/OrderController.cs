using BLL.DTO.OrderDtos;
using BLL.Managers.Abstract;
using BLL.Managers.Concrete;
using DAL.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ANK19_ETicaret.Areas.Admin.Controllers
{
    [Route("api/[area]/[controller]/[action]")]
    [ApiController]
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderManager _orderManager;


        public OrderController(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OrderDto>> GetOrders()
        {
            var orders = _orderManager.GetAll();

            return Ok(orders);
        }

        [HttpGet]
        public ActionResult GetOrderById(int id)
        {
            var order = _orderManager.GetById(id);

            return Ok(order);
        }

        [HttpPost]
        public ActionResult UpdateOrderStatus([FromBody]UpdateOrderStatusManagerDto dto)
        {
            _orderManager.UpdateOrderStatus(dto.Id, dto.Status);

            return Ok();

        }

    }
}
