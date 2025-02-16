using AutoMapper;
using BLL.DTO;
using BLL.Managers.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ANK19_ETicaret.Areas.Customer.Controllers
{
    [Route("api/[area]/[controller]/[action]")]
    [ApiController]
    [Area("Customer")]
    public class CustomerProductDetailsController : ControllerBase
    {
        private readonly IProductManager _productManager;
        private readonly IMapper _mapper;


        public CustomerProductDetailsController(IProductManager productManager, IMapper mapper)
        {
            _productManager = productManager;
            _mapper = mapper;
        }


        [HttpGet("{id}")]
        public IActionResult GetProductDetails(int id)
        {
            var product = _productManager.GetProductDetails(id);
            return Ok(_mapper.Map<GetProductsDetailsDtoModel>(product));
        }
    }
}
