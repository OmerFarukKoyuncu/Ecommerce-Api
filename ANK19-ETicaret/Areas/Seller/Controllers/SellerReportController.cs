using ANK19_ETicaret.Areas.Admin.Controllers;
using BLL.DTO.OrderDtos;
using BLL.DTO.OrderReportDtos;
using BLL.Managers.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ANK19_ETicaret.Areas.Seller.Controllers
{
	[Route("api/[area]/[controller]/[action]")]
	[ApiController]
	[Area("Seller")]
	
	public class SellerReportController : ControllerBase
	{
		private readonly ILogger<OrderReportController> _logger;
		private readonly IOrderReportManager _reportManager;

		public SellerReportController(ILogger<OrderReportController> logger, IOrderReportManager reportManager)
		{
			_logger = logger;
			_reportManager = reportManager;
		}

		[HttpGet]
		public ActionResult<IEnumerable<OrderReportDto>> GetOrderProductReports([FromQuery]int sellerId)
		{
			try
			{
				_logger.LogInformation("Fetching all order reports");
				var reports = _reportManager.GetOrderProductReportBySeller(sellerId);
				return Ok(reports);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred while fetching order reports");
				return StatusCode(500, "An error occurred while retrieving order reports.");
			}
		}
        [HttpGet]
        public ActionResult<IEnumerable<MonthlyOrderReportDto>> GetMonthlyOrders([FromQuery] int sellerId, [FromQuery] int year)
        {
            try
            {
                _logger.LogInformation("Fetching all order reports");
                var reports = _reportManager.MonthlyOrderReports(sellerId,year);
                return Ok(reports);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching order reports");
                return StatusCode(500, "An error occurred while retrieving order reports.");
            }
        }
    }
}
