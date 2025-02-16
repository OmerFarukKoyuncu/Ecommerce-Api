using AutoMapper;
using BLL.DTO;
using BLL.DTO.ProductDtos;
using BLL.Managers.Abstract;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ANK19_ETicaret.Areas.Admin.Controllers
{
    [Route("api/[area]/[controller]/[action]")]
    [ApiController]
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
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

            _productManager.AddProduct(addProductDtoModel);

            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            _productManager.Remove(id);
            return NoContent();
        }
        [HttpPut]
        public IActionResult UpdateProduct([FromForm] UpdateProductDtoModel updateProductDtoModel)
        {
            _productManager.UpdateProduct(updateProductDtoModel);
            return Ok();
        }
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _productManager.GetAll();
            return Ok(_mapper.Map<List<GetAllProductsDtoModel>>(products));
        }
        [HttpGet("{id}")]
        public IActionResult GetProductDetails(int id)
        {
            var product = _productManager.GetProductDetails(id);
            return Ok(_mapper.Map<GetProductsDetailsDtoModel>(product));
        }
        [HttpGet]
        public IActionResult GetAllProductsWithCategories()
        {
            var products = _productManager.GetAllProductsWithCategories();
            return Ok(_mapper.Map<List<GetAllProductWithCategoriesDtoModel>>(products));
        }
        [HttpGet]
        public IActionResult GetAllProductsWithSeller()
        {
            var products = _productManager.GetAll();
            return Ok(_mapper.Map<List<GetAllProductsWithSellerDtoModel>>(products));
        }
    }
}
