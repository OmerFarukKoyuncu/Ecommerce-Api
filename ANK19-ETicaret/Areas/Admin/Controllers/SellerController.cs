using ANK19_ETicaret.Controllers;
using AutoMapper;
using BLL.DTO.Category;
using BLL.DTO.Seller;
using BLL.Managers.Abstract;
using BLL.Managers.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ANK19_ETicaret.Areas.Admin.Controllers
{
    [Route ("api/[area]/[controller]/[action]")]
    [ApiController]
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SellerController(ILogger<SellerController> _logger, ISellerManager _sellerManager, IMapper _mapper) : ControllerBase
    {

        /// <summary>
        /// Yeni bir satıcı oluşturur.
        /// </summary>
        [HttpPost]
        public ActionResult<int> AddSeller (SellerDTOModel sellerDTOModel)
        {
            try
            {
                _logger.LogInformation ("Add new Seller");
                var id = _sellerManager.Add (sellerDTOModel);
                return Ok ($"{id}");
            }
            catch (Exception ex)
            {
                _logger.LogError (ex, "An error occurred while fetching sellers");
                return StatusCode (500, "An error occurred while retrieving sellers.");
            }
        }

        /// <summary>
        /// Bütün Satıcıları getiren endpoint
        /// </summary>
        /// <returns></returns>

        [HttpGet (Name = "GetAllSellers")]
        public IActionResult GetAllSeller ()
        {
            try
            {
                _logger.LogInformation ("Fetching all sellers");
                var sellers = _sellerManager.GetAll ();
                return Ok (sellers);
            }
            catch (Exception ex)
            {
                _logger.LogError (ex, "An error occurred while fetching seller");
                return StatusCode (500, "An error occurred while retrieving seller.");
            }
        }

        [HttpGet ("{id}")]
        public IActionResult GetSellerById (int id)
        {
            try
            {
                _logger.LogInformation ("Fetching all sellers");
                var seller = _sellerManager.GetById (id);
                return Ok (seller);
            }
            catch (Exception ex)
            {
                _logger.LogError (ex, "An error occurred while fetching seller");
                return StatusCode (500, "An error occurred while retrieving seller.");
            }
        }


        [HttpGet (Name = "GetAllSellersWithProduct")]
        public IActionResult GetAllSellersWithProduct ()
        {
            try
            {
                _logger.LogInformation ("Fetching all sellers");
                var sellers = _sellerManager.GetWhere (x=>x.Products != null);
                return Ok (sellers);
            }
            catch (Exception ex)
            {
                _logger.LogError (ex, "An error occurred while fetching seller");
                return StatusCode (500, "An error occurred while retrieving seller.");
            }
        }

        /// <summary>
        /// Satıcıların oyaylı satıcı olması için endpoint
        /// </summary>
        [HttpPost ("{id}")]
        public IActionResult GetApprovedSeller (int id)
        {
            try
            {
                var seller = _sellerManager.ApprovedBySeller (id);
                _logger.LogInformation ($"{seller.Name} is approved {DateTime.Now}");
                return Ok ($"{seller.Name} is approved = {seller.IsApproved}");
            }
            catch (Exception ex)
            {
                _logger.LogError (ex, "An error occurred while fetching seller");
                return StatusCode (500, "An error occurred while retrieving seller.");
            }

        }

        /// <summary>
        /// Satıcıları silmek için end point
        /// </summary>

        [HttpPost (Name = "DeleteSeller")]
        public ActionResult<int> DeleteSeller (int id)
        {
            try
            {
                _logger.LogInformation ("Fetching all seller");
                _sellerManager.Remove (id);
                return Ok (id);
            }
            catch (Exception ex)
            {
                _logger.LogError (ex, "An error occurred while fetching seller");
                return StatusCode (500, "An error occurred while retrieving seller.");
            }
        }


    }
}
