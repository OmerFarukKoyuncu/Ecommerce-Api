using AutoMapper;
using BLL.DTO;
using BLL.DTO.ProductDtos;
using BLL.Managers.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ANK19_ETicaret.Areas.Seller.Controllers
{
    [Route("api/[area]/[controller]/[action]")]
    [ApiController]
    [Area("Seller")]
    [Authorize(Roles = "Seller")]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager _productManager;
        private readonly IMapper _mapper;

        public ProductController(IProductManager productManager, IMapper mapper)
        {
            _productManager = productManager;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult AddProduct([FromForm] AddProductDtoModel addProductDtoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _productManager.AddProduct(addProductDtoModel);

            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateProduct([FromForm] UpdateProductDtoModel updateProductDtoModel)
        {
            _productManager.UpdateProduct(updateProductDtoModel);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetProductDetails(int id)
        {
            var product = _productManager.GetProductDetails(id);
            return Ok(_mapper.Map<GetProductsDetailsDtoModel>(product));
        }

        [HttpGet]
        public IActionResult GetProductsBySeller(int sellerId)
        {
            var products = _productManager.GetProductsBySeller(sellerId);
            return Ok(products);
        }
    }
}
