using AutoMapper;
using BLL.DTO.Category;
using BLL.DTO.CustomerDto;
using BLL.Managers.Abstract;
using BLL.Managers.Concrete;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace ANK19_ETicaret.Areas.Customer.Controllers
{

    [Route("api/[area]/[controller]/[action]")]
    [ApiController]
    [Area("Customer")]
 
    public class CustomerProductListController : Controller
    {
        private readonly ICustomerProductListManager _customerProductListManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public CustomerProductListController(ICustomerProductListManager customerProductListManager, IHttpContextAccessor httpContextAccessor, IMapper mapper, UserManager<User> userManager)
        {
            _customerProductListManager = customerProductListManager;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetProductList()
        {

            try
            {
                var productList = _customerProductListManager.GetCustomerProductList();
                return Ok(productList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Bir hata oluştu: " + ex.Message);
            }


        }

        [HttpGet]
        public async Task<IActionResult> GetProductListByName(string name)
        {

            try
            {
                var productList = _customerProductListManager.GetCustomerProductList();
                productList= productList.Where(x=>x.Description.Contains(name)||x.Name.Contains(name)).ToList();
                return Ok(productList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Bir hata oluştu: " + ex.Message);
            }


        }

        [HttpGet]
        public async Task<IActionResult> GetProductListByCategoryName(string name)
        {

            try
            {
                var productList = _customerProductListManager.GetCustomerProductList();
                productList = productList.Where(x => x.ProductCategories.Where(x => x.Category.Name == name).Count() > 0).ToList();
                return Ok(productList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Bir hata oluştu: " + ex.Message);
            }


        }



        [HttpGet]
        public async Task<IActionResult> GetProductCategoryList()
        {

            try
            {
                var productList = _customerProductListManager.GetCustomerProductList();
                List<CategoryDTOModel> list = new List<CategoryDTOModel>();
                foreach (var item in productList)
                {
                    foreach (var item2 in item.ProductCategories)
                    {
                        if (list.Where(x=>x.Name==item2.Category.Name).Count()==0)
                        {
                            list.Add(item2.Category);
                        }
                       
                    }
                  
                }

               
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Bir hata oluştu: " + ex.Message);
            }


        }

    }
}
