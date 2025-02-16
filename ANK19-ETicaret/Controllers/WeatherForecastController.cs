using AutoMapper;
using BLL.DTO.Category;
using BLL.Managers.Abstract;
using DAL.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ANK19_ETicaret.Controllers
{
    [ApiController]
    [Route ("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ICategoryManager _categoryManager;
        private readonly IMapper _mapper;

        public WeatherForecastController (ILogger<WeatherForecastController> logger, ICategoryManager categoryManager, IMapper mapper)
        {
            _logger = logger;
            _categoryManager = categoryManager;
            _mapper = mapper;
        }

        [HttpGet (Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get ()
        {
            return Enumerable.Range (1, 5).Select (index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime (DateTime.Now.AddDays (index)),
                TemperatureC = Random.Shared.Next (-20, 55),
                Summary = Summaries[Random.Shared.Next (Summaries.Length)]
            })
            .ToArray ();
        }




       



        [HttpGet("GetCategories", Name = "GetCategories")]
        public ActionResult<IEnumerable<CategoryDTOModel>> GetCategories()
        {
            try
            {
                _logger.LogInformation("Fetching all categories");
                var categories = _categoryManager.GetAll();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching categories");
                return StatusCode(500, "An error occurred while retrieving categories.");
            }
        }



        [HttpPost("PostCategories", Name = "PostCategories")]
        public ActionResult<int> PostCategories(AddCategoryDTOModel addCategoryDTO)
        {
            try
            {
                _logger.LogInformation("Fetching all categories");
                var id = _categoryManager.Add(_mapper.Map<CategoryDTOModel>(addCategoryDTO));
                return Ok(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching categories");
                return StatusCode(500, "An error occurred while retrieving categories.");
            }
        }

        [HttpPost("DeleteCategories", Name = "DeleteCategories")]
        public ActionResult<int> DeleteCategories(int id)
        {
            try
            {
                _logger.LogInformation("Fetching all categories");
                 _categoryManager.Remove(id);
                return Ok(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching categories");
                return StatusCode(500, "An error occurred while retrieving categories.");
            }
        }


        [HttpPost("UpdateCategories", Name = "UpdateCategories")]
        public ActionResult<int> UpdateCategories(int id, AddCategoryDTOModel updateCategory)
        {
            try
            {
                _logger.LogInformation("Fetching all categories");
                var category = _categoryManager.GetById(id);

                _mapper.Map(updateCategory, category);

                _categoryManager.Update(category);
                return Ok(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching categories");
                return StatusCode(500, "An error occurred while retrieving categories.");
            }
        }
    }
}
