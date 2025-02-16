using ANK19_ETicaret.Controllers;
using AutoMapper;
using BLL.DTO.PromotionsDtos;
using BLL.Managers.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ANK19_ETicaret.Areas.Seller.Controllers
{
    [Route("api/[area]/[controller]/[action]")]
    [ApiController]
    [Area("Seller")]
    //[Authorize(Roles = "Seller")]
    public class ProductPromotionController : ControllerBase
    {
      
        private readonly IProductPromotionsManager _productPromotionsManager;
        private readonly IMapper _mapper;

        public ProductPromotionController( IProductPromotionsManager productPromotionsManager, IMapper mapper)
        {
           
            _productPromotionsManager = productPromotionsManager;
            _mapper = mapper;
        }

        // GET: api/Promotions
        [HttpGet]
        public ActionResult<IEnumerable<ProductPromotionDtoModel>> GetProductPromotions()
        {
            return _productPromotionsManager.GetAll();
        }

        // GET: api/Promotions/5
        [HttpGet("{id}")]
        public ActionResult<ProductPromotionDtoModel> GetPromotion(int id)
        {
            var ProductPromotion = _productPromotionsManager.GetById(id);

            if (ProductPromotion == null)
            {
                return NotFound();
            }

            return ProductPromotion;
        }

        // PUT: api/Promotions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPromotion(int id, AddProductPromotionDtoModel updatePromotion)
        {



            try
            {
                 
                var promotion = _productPromotionsManager.GetById(id);

                _mapper.Map(updatePromotion, promotion);

                _productPromotionsManager.Update(promotion);

                return Ok(id);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, "An error occurred while retrieving categories.");
            }
        }

        // POST: api/Promotions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductPromotionDtoModel>> PostProductPromotion(AddProductPromotionDtoModel promotion)
        {

            try
            {
        
                var id = _productPromotionsManager.Add(_mapper.Map<ProductPromotionDtoModel>(promotion));
                return Ok(id);
            }
            catch (Exception ex)
            {
      
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE: api/Promotions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductPromotion(int id)
        {
            var promotion = _productPromotionsManager.GetById(id);
            if (promotion == null)
            {
                return NotFound();
            }

            _productPromotionsManager.Remove(promotion);


            return NoContent();
        }

        private bool ProductPromotionExists(int id)
        {
            return _productPromotionsManager.GetAll().Any(e => e.Id == id);
        }
    }
}
