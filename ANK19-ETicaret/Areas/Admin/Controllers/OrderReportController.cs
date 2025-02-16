using ANK19_ETicaret.Controllers;
using BLL.DTO.Category;
using BLL.DTO.OrderReportDtos;
using BLL.Managers.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace ANK19_ETicaret.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("api/[area]/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class OrderReportController : ControllerBase
    {
        private readonly ILogger<OrderReportController> _logger;
        private readonly IOrderReportManager _reportManager;

        public OrderReportController(ILogger<OrderReportController> logger, IOrderReportManager reportManager)
        {
            _logger = logger;
            _reportManager = reportManager;
        }

        [HttpGet(Name = "GetOrderReports")]
        public ActionResult<IEnumerable<OrderReportDto>> GetOrderReports()
        {
            try
            {
                _logger.LogInformation("Fetching all order reports");
                var reports = _reportManager.GetOrderReport();
                return Ok(reports);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching order reports");
                return StatusCode(500, "An error occurred while retrieving order reports.");
            }
        }


        [HttpGet(Name = "GetOrderProductReports")]
        public ActionResult<IEnumerable<OrderReportDto>> GetOrderProductReports()
        {
            try
            {
                _logger.LogInformation("Fetching all order reports");
                var reports = _reportManager.GetOrderProductReport();
                return Ok(reports);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching order reports");
                return StatusCode(500, "An error occurred while retrieving order reports.");
            }
        }

        [HttpGet(Name = "GetOrderCustomerReports")]
        public ActionResult<IEnumerable<OrderCustomerReportDTO>> GetOrderCustomerReports()
        {
            try
            {
                _logger.LogInformation("Fetching all order reports");
                var reports = _reportManager.GetOrderCustomerReport();
                return Ok(reports);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching order reports");
                return StatusCode(500, "An error occurred while retrieving order reports.");
            }
        }


        [HttpGet(Name = "GetOrderSellerReports")]
        public ActionResult<IEnumerable<OrderSellerReportDTO>> GetOrderSellerReports()
        {
            try
            {
                _logger.LogInformation("Fetching all order reports");
                var reports = _reportManager.GetOrderSellerReport();
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
