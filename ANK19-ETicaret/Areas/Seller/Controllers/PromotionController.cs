using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.Data;
using DAL.Entities;
using BLL.Managers.Abstract;
using AutoMapper;
using BLL.DTO.PromotionsDtos;
using BLL.Managers.Concrete;
using ANK19_ETicaret.Controllers;
using BLL.DTO.Category;
using Microsoft.AspNetCore.Authorization;

namespace ANK19_ETicaret.Areas.Seller.Controllers
{

    [Route("api/[area]/[controller]/[action]")]
    [ApiController]
    [Area("Seller")]
    //[Authorize(Roles = "Seller")]
    public class PromotionController : ControllerBase
    {
   
        private readonly IPromotionsManager _promotionsManager;
        private readonly IMapper _mapper;

        public PromotionController( IPromotionsManager promotionsManager, IMapper mapper)
        {
           
            _promotionsManager = promotionsManager;
            _mapper = mapper;
        }

        // GET: api/Promotions
        [HttpGet]
        public ActionResult<IEnumerable<PromotionDtoModel>> GetPromotions()
        {
            return _promotionsManager.GetAll();
        }

        // GET: api/Promotions/5
        [HttpGet("{id}")]
        public ActionResult<PromotionDtoModel> GetPromotion(int id)
        {
            var promotion = _promotionsManager.GetById(id);

            if (promotion == null)
            {
                return NotFound();
            }

            return promotion;
        }

        // PUT: api/Promotions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPromotion(int id, [FromForm] AddPromotionDtoModel updatePromotion)
        {
            try
            {
              
                var promotion = _promotionsManager.GetById(id);

                _mapper.Map(updatePromotion, promotion);
                promotion.Product = null;
                _promotionsManager.Update(promotion);

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
        public async Task<ActionResult<Promotion>> PostPromotion([FromForm]  AddPromotionDtoModel promotion)
        {

            try
            {
               
                var id = _promotionsManager.Add(_mapper.Map<PromotionDtoModel>(promotion));
                return Ok(id);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, "An error occurred while posting promotion.");
            }
        }

        // DELETE: api/Promotions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePromotion(int id)
        {
            var promotion = _promotionsManager.GetById(id);
            if (promotion == null)
            {
                return NotFound();
            }

            _promotionsManager.Remove(promotion);


            return NoContent();
        }

        private bool PromotionExists(int id)
        {
            return _promotionsManager.GetAll().Any(e => e.Id == id);
        }
    }
}
