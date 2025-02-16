using AutoMapper;
using BLL.DTO.Category;
 
using BLL.Managers.Abstract;
using BLL.Managers.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ANK19_ETicaret.Areas.Admin.Controllers
{
    [Route("api/[area]/[controller]/[action]")]
    [ApiController]
    [Area("Admin")]
    [Authorize(Roles = "Admin,Seller")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryManager _categoryManager;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryManager categoryManager,IMapper mapper)
        {
            _categoryManager = categoryManager;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _categoryManager.GetAll();
            var mapped = _mapper.Map<List<CategoryDTOModel>>(categories);
            return Ok(_mapper.Map<List<AddCategoryDTOModel>>(mapped));
        }
    }
}
